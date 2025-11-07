@echo off
echo ========================================
echo Building Desktop Goose Chat Mod
echo ========================================

set GOOSE_PATH=C:\Users\irrev\Documents\Privat\DesktopGoose

echo.
echo [1/4] Cleaning previous build...
dotnet clean ChatWithGooseMod.csproj

echo.
echo [2/4] Restoring packages...
dotnet restore ChatWithGooseMod.csproj

echo.
echo [3/4] Building project...
dotnet build ChatWithGooseMod.csproj -c Release

if %errorlevel% neq 0 goto error

echo.
echo [4/4] Installing mod to Desktop Goose...

REM Create mod folder in Assets/Mods
if not exist "%GOOSE_PATH%\Assets\Mods\ChatWithGooseMod" mkdir "%GOOSE_PATH%\Assets\Mods\ChatWithGooseMod"

REM Copy DLL (NOT the API DLL, just our mod)
copy /Y "bin\Release\net452\ChatWithGooseMod.dll" "%GOOSE_PATH%\Assets\Mods\ChatWithGooseMod\"

echo.
echo ========================================
echo BUILD AND INSTALL SUCCESSFUL!
echo ========================================
echo.
echo Mod installed to: %GOOSE_PATH%\Assets\Mods\ChatWithGooseMod\
echo.
echo NEXT STEPS:
echo 1. Make sure mods are enabled in Desktop Goose config
echo 2. Restart Desktop Goose (GooseDesktop.exe)
echo 3. The goose will randomly open chat windows!
echo.
pause
exit

:error
echo.
echo ========================================
echo BUILD FAILED!
echo ========================================
echo.
echo Check the errors above.
pause
exit /b 1