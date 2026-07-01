@echo off
setlocal

set ROOT=D:\666\work\WR.Next
set RUNTIME_ROOT=%ROOT%\src\WR.OriginalUiHost\bin\Debug\net48
set HOST_EXE=%RUNTIME_ROOT%\WR.OriginalUiHost.exe

title WR.Next - Run Latest UI Host
cd /d "%ROOT%"

if not exist "%HOST_EXE%" (
    echo Runtime output not found.
    echo Building first...
    call "%ROOT%\build-uihost.bat"
    if errorlevel 1 goto :fail
)

powershell -ExecutionPolicy Bypass -Command "Set-Location '%RUNTIME_ROOT%'; $env:WR_RUNTIME_ROOT='%RUNTIME_ROOT%'; Start-Process -FilePath '%HOST_EXE%' -WorkingDirectory '%RUNTIME_ROOT%'"
if errorlevel 1 goto :fail
goto :eof

:fail
echo.
echo Run failed.
echo.
pause
exit /b 1
