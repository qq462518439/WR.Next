param(
    [string]$BuildRoot = "D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48",
    [string]$RuntimeSourceRoot = "D:\666\RZB",
    [string]$DiagnosticsRoot = "D:\666\work\WR.Next\tools\diagnostics",
    [string]$OutputRoot = "D:\666\work\WR.Next\artifacts\uihost-runtime-layout",
    [switch]$Incremental
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

function Ensure-Directory {
    param([string]$Path)

    if (-not (Test-Path -LiteralPath $Path)) {
        New-Item -ItemType Directory -Path $Path | Out-Null
    }
}

function Reset-Directory {
    param([string]$Path)

    if (Test-Path -LiteralPath $Path) {
        Remove-Item -LiteralPath $Path -Recurse -Force
    }

    New-Item -ItemType Directory -Path $Path | Out-Null
}

function Copy-FileSet {
    param(
        [string[]]$Paths,
        [string]$Destination
    )

    Ensure-Directory -Path $Destination

    foreach ($path in $Paths) {
        if (Test-Path -LiteralPath $path) {
            $targetPath = Join-Path $Destination ([System.IO.Path]::GetFileName($path))
            try {
                Copy-Item -LiteralPath $path -Destination $Destination -Force
            }
            catch {
                throw "Copy failed: '$path' -> '$targetPath'. $($_.Exception.Message)"
            }
        }
    }
}

function Copy-FileRobust {
    param(
        [string]$Source,
        [string]$Destination
    )

    if (-not (Test-Path -LiteralPath $Source)) {
        return
    }

    $targetPath = Join-Path $Destination ([System.IO.Path]::GetFileName($Source))

    for ($attempt = 1; $attempt -le 5; $attempt++) {
        try {
            if (Test-Path -LiteralPath $targetPath) {
                Remove-Item -LiteralPath $targetPath -Force
            }

            Copy-Item -LiteralPath $Source -Destination $targetPath -Force
            return
        }
        catch {
            if ($attempt -eq 5) {
                throw "Copy failed: '$Source' -> '$targetPath'. $($_.Exception.Message)"
            }

            Start-Sleep -Milliseconds (200 * $attempt)
        }
    }
}

function Copy-TreeIfExists {
    param(
        [string]$Source,
        [string]$Destination
    )

    if (Test-Path -LiteralPath $Source) {
        $sourceFull = [System.IO.Path]::GetFullPath($Source).TrimEnd('\')
        $destinationFull = [System.IO.Path]::GetFullPath($Destination).TrimEnd('\')
        if ($sourceFull -eq $destinationFull) {
            return
        }
        Copy-Item -LiteralPath $Source -Destination $Destination -Recurse -Force
    }
}

function Copy-DirectoryContentsIfExists {
    param(
        [string]$SourceDirectory,
        [string]$Destination
    )

    if (-not (Test-Path -LiteralPath $SourceDirectory)) {
        return
    }

    Ensure-Directory -Path $Destination

    Get-ChildItem -LiteralPath $SourceDirectory -Force | ForEach-Object {
        Copy-Item -LiteralPath $_.FullName -Destination $Destination -Recurse -Force
    }
}

function Copy-FilteredDirectoryContents {
    param(
        [string]$SourceDirectory,
        [string]$Destination,
        [string[]]$IncludeNames
    )

    if (-not (Test-Path -LiteralPath $SourceDirectory)) {
        return
    }

    Ensure-Directory -Path $Destination

    foreach ($name in $IncludeNames) {
        $sourcePath = Join-Path $SourceDirectory $name
        if (Test-Path -LiteralPath $sourcePath) {
            Copy-Item -LiteralPath $sourcePath -Destination $Destination -Recurse -Force
        }
    }
}

function Assert-FileEquivalent {
    param(
        [string]$Source,
        [string]$Destination
    )

    if (-not (Test-Path -LiteralPath $Source)) {
        throw "Publish validation missing source: $Source"
    }

    if (-not (Test-Path -LiteralPath $Destination)) {
        throw "Publish validation missing destination: $Destination"
    }

    $sourceHash = (Get-FileHash -LiteralPath $Source -Algorithm SHA256).Hash
    $destinationHash = (Get-FileHash -LiteralPath $Destination -Algorithm SHA256).Hash

    if ($sourceHash -ne $destinationHash) {
        throw "Publish validation mismatch: '$Source' -> '$Destination'"
    }
}

$logsRoot = Join-Path $OutputRoot "logs"
$toolsRoot = Join-Path $OutputRoot "tools"
$dataRoot = Join-Path $OutputRoot "Data"
$binRoot = Join-Path $OutputRoot "Bin"
$productsRoot = Join-Path $OutputRoot "Products"
$pluginsRoot = Join-Path $OutputRoot "Plugins"
$fightClassRoot = Join-Path $OutputRoot "FightClass"
$profilesRoot = Join-Path $OutputRoot "Profiles"
$settingsRoot = Join-Path $OutputRoot "Settings"

if ($Incremental) {
    Ensure-Directory -Path $OutputRoot
    Ensure-Directory -Path $logsRoot
    Ensure-Directory -Path $toolsRoot
    Ensure-Directory -Path $dataRoot
    Ensure-Directory -Path $binRoot
    Ensure-Directory -Path $productsRoot
    Ensure-Directory -Path $pluginsRoot
    Ensure-Directory -Path $fightClassRoot
    Ensure-Directory -Path $profilesRoot
    Ensure-Directory -Path $settingsRoot
}
else {
    Reset-Directory -Path $OutputRoot
    Ensure-Directory -Path $logsRoot
    Ensure-Directory -Path $toolsRoot
    Ensure-Directory -Path $dataRoot
    Ensure-Directory -Path $binRoot
    Ensure-Directory -Path $productsRoot
    Ensure-Directory -Path $pluginsRoot
    Ensure-Directory -Path $fightClassRoot
    Ensure-Directory -Path $profilesRoot
    Ensure-Directory -Path $settingsRoot
}

$rootFiles = @(
    (Join-Path $BuildRoot "WR.OriginalUiHost.exe"),
    (Join-Path $BuildRoot "WR.OriginalUiHost.exe.config"),
    (Join-Path $BuildRoot "WR.OriginalUiHost.pdb"),
    (Join-Path $RuntimeSourceRoot "WRobot.exe"),
    (Join-Path $RuntimeSourceRoot "WRobot.exe.config")
)

foreach ($rootFile in $rootFiles) {
    Copy-FileRobust -Source $rootFile -Destination $OutputRoot
}

$exeConfigPath = Join-Path $OutputRoot "WR.OriginalUiHost.exe.config"
$exeConfig = @"
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.8" />
  </startup>
  <runtime>
    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
      <probing privatePath="Bin" />
    </assemblyBinding>
  </runtime>
</configuration>
"@
[System.IO.File]::WriteAllText($exeConfigPath, $exeConfig, [System.Text.UTF8Encoding]::new($false))

$binFiles = @(
    (Join-Path $BuildRoot "authManager.dll"),
    (Join-Path $BuildRoot "ControlzEx.dll"),
    (Join-Path $BuildRoot "ICSharpCode.SharpZipLib.dll"),
    (Join-Path $BuildRoot "MahApps.Metro.dll"),
    (Join-Path $BuildRoot "MahApps.Metro.IconPacks.Material.dll"),
    (Join-Path $BuildRoot "MemoryRobot.dll"),
    (Join-Path $BuildRoot "Neo.Lua.dll"),
    (Join-Path $BuildRoot "Newtonsoft.Json.dll"),
    (Join-Path $BuildRoot "robotManager.dll"),
    (Join-Path $BuildRoot "rStyle.dll"),
    (Join-Path $BuildRoot "ScintillaNET.dll"),
    (Join-Path $BuildRoot "ScintillaNET.WPF.dll"),
    (Join-Path $BuildRoot "SlimDX.dll"),
    (Join-Path $BuildRoot "System.Windows.Interactivity.dll"),
    (Join-Path $BuildRoot "UpdateManager.dll"),
    (Join-Path $BuildRoot "wManager.dll"),
    (Join-Path $BuildRoot "wResources.dll"),
    (Join-Path $RuntimeSourceRoot "Bin\RDManaged.dll"),
    (Join-Path $RuntimeSourceRoot "Bin\fasmdll_managed.dll")
)

foreach ($binFile in $binFiles) {
    Copy-FileRobust -Source $binFile -Destination $binRoot
}

if (-not $Incremental) {
    Copy-FilteredDirectoryContents -SourceDirectory (Join-Path $RuntimeSourceRoot "Data") -Destination $dataRoot -IncludeNames @(
        "Lang",
        "Digsites.xml",
        "Meshes",
        "Minimaps",
        "NpcDB.xml",
        "OffMeshConnections.xml",
        "autoMakeElementalMacro.txt",
        "temp"
    )
    Copy-DirectoryContentsIfExists -SourceDirectory (Join-Path $BuildRoot "FightClass") -Destination $fightClassRoot
    Copy-DirectoryContentsIfExists -SourceDirectory (Join-Path $BuildRoot "Plugins") -Destination $pluginsRoot
    Copy-DirectoryContentsIfExists -SourceDirectory (Join-Path $BuildRoot "Products") -Destination $productsRoot
    Copy-DirectoryContentsIfExists -SourceDirectory (Join-Path $RuntimeSourceRoot "FightClass") -Destination $fightClassRoot
    Copy-DirectoryContentsIfExists -SourceDirectory (Join-Path $RuntimeSourceRoot "Plugins") -Destination $pluginsRoot
    Copy-DirectoryContentsIfExists -SourceDirectory (Join-Path $RuntimeSourceRoot "Products") -Destination $productsRoot
    Copy-TreeIfExists -Source (Join-Path $RuntimeSourceRoot "Profiles") -Destination $profilesRoot
    Copy-DirectoryContentsIfExists -SourceDirectory (Join-Path $BuildRoot "Settings") -Destination $settingsRoot
    Copy-DirectoryContentsIfExists -SourceDirectory (Join-Path $RuntimeSourceRoot "Settings") -Destination $settingsRoot
    Copy-TreeIfExists -Source $DiagnosticsRoot -Destination $toolsRoot
}

$readme = @"
WR.OriginalUiHost 聚合运行目录

根目录     主程序、启动配置与目录结构
Bin       全部运行时 DLL 与原版动态编译依赖
Data      数据资源
Products  产品模块
Plugins   插件
FightClass 战斗职业
Profiles  配置脚本
Settings  设置
logs      运行日志
tools     诊断工具
"@

[System.IO.File]::WriteAllText((Join-Path $OutputRoot "README.txt"), $readme, [System.Text.UTF8Encoding]::new($true))

$launchScript = @'
param(
    [switch]$NoWindow
)

$ErrorActionPreference = "Stop"

$root = Split-Path -Parent $MyInvocation.MyCommand.Path
$exe = Join-Path $root "WR.OriginalUiHost.exe"

if (-not (Test-Path -LiteralPath $exe)) {
    throw "Cannot find main executable: $exe"
}

$startParams = @{
    FilePath = $exe
    WorkingDirectory = $root
}

if (-not $NoWindow) {
    $startParams.WindowStyle = "Normal"
}

Start-Process @startParams
'@

[System.IO.File]::WriteAllText((Join-Path $OutputRoot "Launch-OriginalUiHost.ps1"), $launchScript, [System.Text.UTF8Encoding]::new($true))

Assert-FileEquivalent -Source (Join-Path $BuildRoot "WR.OriginalUiHost.exe") -Destination (Join-Path $OutputRoot "WR.OriginalUiHost.exe")
Assert-FileEquivalent -Source (Join-Path $BuildRoot "WR.OriginalUiHost.pdb") -Destination (Join-Path $OutputRoot "WR.OriginalUiHost.pdb")
Assert-FileEquivalent -Source (Join-Path $BuildRoot "wManager.dll") -Destination (Join-Path $binRoot "wManager.dll")
Assert-FileEquivalent -Source (Join-Path $BuildRoot "robotManager.dll") -Destination (Join-Path $binRoot "robotManager.dll")
Assert-FileEquivalent -Source (Join-Path $BuildRoot "MemoryRobot.dll") -Destination (Join-Path $binRoot "MemoryRobot.dll")

Get-ChildItem -LiteralPath $OutputRoot | Select-Object Name, Mode
