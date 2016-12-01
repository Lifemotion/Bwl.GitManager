taskkill /f /im Bwl.GitManager.exe
taskkill /f /im Bwl.GitManager.exe
tools\vs-build-all.exe -debug -release *
if %nopause%==true goto end
pause
:end