@echo off
setlocal

set ROOT=D:\666\work\WR.Next
set RUNTIME_ROOT=%ROOT%\artifacts\uihost-runtime-layout
set LAUNCHER=%RUNTIME_ROOT%\Launch-OriginalUiHost.ps1

title WR.Next - Run Latest UI Host
cd /d "%ROOT%"

if not exist "%LAUNCHER%" (
    echo Runtime layout not found.
    echo Building first...
    call "%ROOT%\build-uihost.bat"
    if errorlevel 1 goto :fail
)

powershell -ExecutionPolicy Bypass -File "%LAUNCHER%"
if errorlevel 1 goto :fail
goto :eof

:fail
echo.
echo Run failed.
echo.
pause
exit /b 1
