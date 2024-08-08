@echo off
for %%X in (gpi, dri, lck, l#1, l#2, l#3, l#4, l#5, l#6, l#7, l#8, l#9, b#1, b#2, b#3, b#4, b#5, b#6, b#7, b#8, b#9, s#1, s#2, s#3, s#4, s#5, s#6, s#7, s#8, s#9) do (
    del /Q *."%%X" 2>NUL
)
pause
