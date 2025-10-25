echo Copying Assets to Release Dir

@REM Runtime files
xcopy %1\upm\    %1\PuerTS\upm\  /E /Y

@REM DLLs
copy %1\upm\Plugins\x86_64\PapiV8.dll       %1\PuerTS\
copy %1\upm\Plugins\x86_64\PuertsCore.dll   %1\PuerTS\

@REM copy mod
copy %2\PuerTS.dll  %1\PuerTS\
copy %2\PuerTS.pdb  %1\PuerTS\
copy %2\PuerTS.deps.json    %1\PuerTS\
