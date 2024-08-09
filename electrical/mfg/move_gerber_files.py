import os
import shutil
import zipfile

project_names = ["shrew-lite", "shrew-pro"]
file_extensions = ["txt", "xln", "do", "gml", "gtp", "gts", "gto", "gtl", "gbp", "gbs", "gbo", "gbl", "g2l", "g3l"]
delete_extensions = ["dri", "gpi"]

for d in project_names:
    os.makedirs(d, exist_ok=True)

    f_list = []

    for filename in os.listdir(".."):
        fpath = os.path.abspath(os.path.join("..", filename))
        basename = os.path.basename(fpath)
        fname = os.path.splitext(basename)[0]
        fext = os.path.splitext(basename)[1][1:].lower()
        if fname.startswith(d + "-") and fext in file_extensions:
            nfpath = os.path.abspath(os.path.join(d, basename))
            shutil.move(fpath, nfpath)
            print(f"moved '{fpath}' => '{nfpath}'")
            f_list.append(nfpath)
        elif fext in delete_extensions:
            os.remove(fpath)
            print(f"deleted '{fpath}'")

    if len(f_list) > 0:
        zip_path = os.path.abspath(os.path.join(d, d + ".zip"))
        if os.path.exists(zip_path):
            os.remove(zip_path)
        with zipfile.ZipFile(zip_path, 'w') as myzip:
            for mfile in f_list:
                myzip.write(mfile, arcname=os.path.basename(mfile))

        gv_template_path = os.path.abspath("gerbv_template.gvp")
        gv_output_path = os.path.abspath(os.path.join(d, "gerbv.gvp"))
        if os.path.exists(gv_template_path) and not os.path.exists(gv_output_path):
            with open(gv_template_path, "r") as f_src:
                contents = f_src.read()
                n_contents = contents.replace("REPLACEME", d)
                with open(gv_output_path, "w") as f_dest:
                    f_dest.write(n_contents)
                    print(f"written gerbv file '{gv_output_path}'")
