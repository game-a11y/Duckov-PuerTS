echo Copying Assets to %2

@REM Runtime files
xcopy %1\upm\    %2\upm\  /E /Y

@REM DLLs
copy %1\upm\Plugins\x86_64\PapiV8.dll        %2
copy %1\upm\Plugins\x86_64\PuertsCore.dll    %2
