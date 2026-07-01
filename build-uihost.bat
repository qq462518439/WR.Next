@echo off
setlocal

set ROOT=D:\666\work\WR.Next
set CSPROJ=%ROOT%\src\WR.OriginalUiHost\WR.OriginalUiHost.csproj
set BUILD_OUT=%ROOT%\src\WR.OriginalUiHost\bin\Debug\net48
set RUNTIME_SYNC_SCRIPT=%ROOT%\tools\layout\Sync-OriginalUiHostMinimalRuntime.ps1

title WR.Next - Build WR.OriginalUiHost
cd /d "%ROOT%"

echo [0/2] Stopping running UI host...
powershell -ExecutionPolicy Bypass -Command "Get-Process WR.OriginalUiHost -ErrorAction SilentlyContinue | Stop-Process -Force"

echo [1/2] Building WR.OriginalUiHost...
dotnet build "%CSPROJ%" -c Debug -o "%BUILD_OUT%"
if errorlevel 1 goto :fail

echo [2/2] Syncing minimal runtime dependencies...
powershell -ExecutionPolicy Bypass -File "%RUNTIME_SYNC_SCRIPT%" -BuildRoot "%BUILD_OUT%"
if errorlevel 1 goto :fail

echo.
echo Build complete.
echo Latest runnable root:
echo %BUILD_OUT%
echo.
pause
goto :eof

:fail
echo.
echo Build failed.
echo.
pause
exit /b 1
