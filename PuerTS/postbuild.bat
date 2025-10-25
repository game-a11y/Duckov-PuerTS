echo Copying Assets to Release Dir

@REM Copy Runtime files
@REM xcopy %1\upm\    %1\PuerTS\upm\  /E /Y
xcopy %1\upm\Editor\Resources\      %1\PuerTS\upm\Editor\Resources\  /E /Y
xcopy %1\upm\Runtime\Resources\     %1\PuerTS\upm\Runtime\Resources\  /E /Y
copy %1\upm\LICENSE         %1\PuerTS\upm\
copy %1\upm\package.json    %1\PuerTS\upm\
copy %1\upm\Plugins\x86_64\*.dll    %1\PuerTS\

@REM Copy MOD dll
copy %2\PuerTS.dll  %1\PuerTS\
copy %2\PuerTS.pdb  %1\PuerTS\
copy %2\PuerTS.deps.json    %1\PuerTS\

@REM Copy mod meta files
copy %1\info.ini        %1\PuerTS\
copy %1\preview.png     %1\PuerTS\
copy %1\..\LICENSE      %1\PuerTS\
copy %1\..\README.md    %1\PuerTS\
