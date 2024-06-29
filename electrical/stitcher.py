import os, sys, time, math

import argparse
import xml.etree.ElementTree as ET
from pathlib import Path
import re

args = None

def add_to_coord(elem, direction, additional):
    attrib_list = [direction]
    for i in range(1, 5):
        attrib_list.append(direction + str(i))
    for a in attrib_list:
        if a in elem.attrib:
            try:
                current_value = float(elem.attrib[a])
                new_value = current_value + additional
                elem.attrib[a] = str(new_value)
            except ValueError:
                pass
    for child in elem:
        add_to_coord(child, direction, additional)

def get_bounds(elem, min_x = None, max_x = None, min_y = None, max_y = None):
    attrib_list = ['x', 'x1', 'x2', 'x3', 'x4', 'y', 'y1', 'y2', 'y3', 'y4']
    for a in attrib_list:
        if a in elem.attrib:
            try:
                current_value = float(elem.attrib[a])
                if a[0] == 'x':
                    min_x = current_value if min_x is None or min_x > current_value else min_x
                    max_x = current_value if max_x is None or max_x < current_value else max_x
                if a[0] == 'y':
                    min_y = current_value if min_y is None or min_y > current_value else min_y
                    max_y = current_value if max_y is None or max_y < current_value else max_y
            except ValueError:
                pass
    for child in elem:
        min_x, max_x, min_y, max_y = get_bounds(child, min_x, max_x, min_y, max_y)
    return min_x, max_x, min_y, max_y

def get_all_parts(elem, d = None):
    if d is None:
        d = dict()
    eleParts = elem.find("drawing/schematic/parts")
    for child in eleParts:
        name = child.attrib["name"]
        if name not in d:
            d[name] = name
    return d

def inc_name(original_string, haystacks = []):
    match = re.search(r'\d+$', original_string)
    if match:
        integer_part = match.group()
        new_integer = int(integer_part) + 1
        incremented_string = original_string[:match.start()] + str(new_integer)
        for h in haystacks:
            while incremented_string in h.values():
                new_integer += 1
                incremented_string = original_string[:match.start()] + str(new_integer)
        return incremented_string
    else:
        if haystacks is None or len(haystacks) <= 0:
            return original_string
        else:
            new_integer = 1
            incremented_string = original_string + str(new_integer)
            for h in haystacks:
                while incremented_string in h.values():
                    new_integer += 1
                    incremented_string = original_string + str(new_integer)
            return original_string + str(new_integer)

def map_part_names(d1, d2):
    dout = dict()
    for i in d2:
        if i in d1 or i in dout.values():
            n = inc_name(i, haystacks = [d1, d2, dout])
            while n in d1 or n in d1.values() or n in dout.values():
                n = inc_name(n, haystacks = [d1, d2, dout])
            dout[i] = n
        else:
            dout[i] = d2[i]
    return dout

def rename_all(elem, whitelist, dic):
    for child in elem:
        for tn, atr in whitelist.items():
            if tn == child.tag and atr in child.attrib:
                if child.attrib[atr] in dic:
                    child.attrib[atr] = dic[child.attrib[atr]]
        rename_all(child, whitelist, dic)

def concatenate_elements(root1, root2, pathstr):
    if pathstr is not None and len(pathstr) > 0:
        ele1 = root1.find(pathstr)
        ele2 = root2.find(pathstr)
    else:
        ele1 = root1
        ele2 = root2
    for child in ele2:
        ele1.append(child)

def merge_nets(root1, root2, pathstr, atr = "name", fn = concatenate_elements):
    if pathstr is not None and len(pathstr) > 0:
        ele1 = root1.find(pathstr)
        ele2 = root2.find(pathstr)
    else:
        ele1 = root1
        ele2 = root2
    for child2 in ele2:
        found = False
        for child1 in ele1:
            if child1.tag == child2.tag and atr in child1.attrib and atr in child2.attrib and child1.attrib[atr] == child2.attrib[atr]:
                if fn is not None:
                    fn(child1, child2, None)
                found = True
                break
        if found == False:
            ele1.append(child2)

def merge_libraries(root1, root2, pathstr):
    global args
    atr = "name"
    ele1 = root1.find(pathstr)
    ele2 = root2.find(pathstr)
    for child2 in ele2:
        if atr not in child2.attrib:
            continue
        found = False
        for child1 in ele1:
            if child1.tag == child2.tag and atr in child1.attrib and atr in child2.attrib and child1.attrib[atr] == child2.attrib[atr]:
                if args.verbose:
                    print(f"merging library \"{child1.attrib[atr]}\"")
                merge_nets(child1, child2, "packages", fn = None)
                if "board" not in pathstr:
                    merge_nets(child1, child2, "symbols", fn = None)
                    merge_nets(child1, child2, "devicesets", fn = None)
                found = True
                break
        if found == False:
            if args.verbose:
                print(f"appending library \"{child1.attrib[atr]}\"")
            ele1.append(child2)

def stitch(fpath1, fpath2, outpath):
    global args
    global rename_dict
    fpath_sch_1 = os.path.abspath(Path(fpath1).resolve().stem + ".sch")
    fpath_brd_1 = os.path.abspath(Path(fpath1).resolve().stem + ".brd")
    fpath_sch_2 = os.path.abspath(Path(fpath2).resolve().stem + ".sch")
    fpath_brd_2 = os.path.abspath(Path(fpath2).resolve().stem + ".brd")

    if outpath is None:
        outpath = ""
    if len(outpath) <= 0:
        outpath = Path(fpath2).resolve().stem + "-integrated"
    outpath_sch = os.path.abspath(Path(outpath).resolve().stem + ".sch")
    outpath_brd = os.path.abspath(Path(outpath).resolve().stem + ".brd")

    if args.verbose:
        print(f"sch 1: {fpath_sch_1}")
        print(f"sch 2: {fpath_sch_2}")
        print(f"brd 1: {fpath_brd_1}")
        print(f"brd 2: {fpath_brd_2}")
        print(f"out sch: {outpath_sch}")
        print(f"out brd: {outpath_brd}")

    tree_sch   = ET.parse(fpath_sch_1)
    tree_brd   = ET.parse(fpath_brd_1)
    tree_sch_2 = ET.parse(fpath_sch_2)
    tree_brd_2 = ET.parse(fpath_brd_2)

    x1, x2, _, _ = get_bounds(tree_sch.getroot().find("drawing/schematic/sheets"))
    x3, x4, _, _ = get_bounds(tree_sch_2.getroot().find("drawing/schematic/sheets"))
    w = x2 - x1
    w *= 1.5
    xn = x1 + w
    x_shift = 0 if x3 > xn else round(xn - x3)

    if args.verbose:
        print(f"schematic X offset {x_shift}")

    x1, x2, y1, y2 = get_bounds(tree_brd.getroot().find("drawing/board/plain"))
    x3, x4, y3, y4 = get_bounds(tree_brd_2.getroot().find("drawing/board/plain"))
    y_shift = 0 if y4 < y1 else ((y4 - y1) + 2)

    if args.verbose:
        print(f"board Y offset {y_shift}")

    d1 = get_all_parts(tree_sch.getroot())
    if args.verbose:
        #print("parts from first schematic: " + str(d1))
        pass
    d2 = get_all_parts(tree_sch_2.getroot())
    if args.verbose:
        #print("parts from second schematic: " + str(d2))
        pass

    rename_dict = map_part_names(d1, d2)
    if args.verbose:
        print("rename dictionary generated")
        #print(rename_dict)

    rename_all(tree_sch_2.getroot().find("drawing/schematic/parts"), {"part": "name"}, rename_dict)
    rename_all(tree_sch_2.getroot().find("drawing/schematic/sheets"), {"instance": "part", "pinref": "part"}, rename_dict)
    rename_all(tree_brd_2.getroot().find("drawing/board/elements"), {"element": "name"}, rename_dict)
    rename_all(tree_brd_2.getroot().find("drawing/board/signals"), {"contactref": "element"}, rename_dict)

    if args.verbose:
        print("parts all renamed")

    add_to_coord(tree_sch_2.getroot().find("drawing/schematic/sheets"), "x", x_shift)
    add_to_coord(tree_brd.getroot().find("drawing/board/elements"), "y", y_shift)
    add_to_coord(tree_brd.getroot().find("drawing/board/signals"), "y", y_shift)
    add_to_coord(tree_brd.getroot().find("drawing/board/plain"), "y", y_shift)

    if args.verbose:
        print("coordinates adjusted")

    concatenate_elements(tree_sch.getroot(), tree_sch_2.getroot(), "drawing/schematic/parts")
    concatenate_elements(tree_sch.getroot(), tree_sch_2.getroot(), "drawing/schematic/sheets/sheet/plain")
    concatenate_elements(tree_sch.getroot(), tree_sch_2.getroot(), "drawing/schematic/sheets/sheet/instances")
    concatenate_elements(tree_brd.getroot(), tree_brd_2.getroot(), "drawing/board/elements")
    concatenate_elements(tree_brd.getroot(), tree_brd_2.getroot(), "drawing/board/plain")

    if args.verbose:
        print("elements concatenated")

    merge_nets(tree_sch.getroot(), tree_sch_2.getroot(), "drawing/schematic/sheets/sheet/nets")
    merge_nets(tree_brd.getroot(), tree_brd_2.getroot(), "drawing/board/signals")

    if args.verbose:
        print("elements merged")

    merge_libraries(tree_sch.getroot(), tree_sch_2.getroot(), "drawing/schematic/libraries")
    merge_libraries(tree_brd.getroot(), tree_brd_2.getroot(), "drawing/board/libraries")

    if args.verbose:
        print("libraries merged")

    tree_sch.write(outpath_sch, encoding='utf-8', xml_declaration=True)
    tree_brd.write(outpath_brd, encoding='utf-8', xml_declaration=True)

    if args.verbose:
        print("files written, all done")

def main():
    global args
    parser = argparse.ArgumentParser(description="Stitcher")
    parser.add_argument("--inp_file_1",  default="shrew-rx.sch"  , help="path to the first schematic")
    parser.add_argument("--inp_file_2",  default="shrew-mini.sch", help="path to the second schematic")
    parser.add_argument("--output_file", default=""              , help="path to the output file")
    parser.add_argument("--verbose",     action="store_true"     , help="verbose debug text")

    args = parser.parse_args()

    stitch(args.inp_file_1, args.inp_file_2, args.output_file)

if __name__ == "__main__":
    main()