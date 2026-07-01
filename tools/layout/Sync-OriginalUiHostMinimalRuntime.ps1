param(
    [string]$BuildRoot = "D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48",
    [string]$RuntimeSourceRoot = "D:\666\RZB"
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

function Copy-One {
    param(
        [string]$Source,
        [string]$DestinationDirectory
    )

    if (-not (Test-Path -LiteralPath $Source)) {
        throw "Missing source: $Source"
    }

    if (-not (Test-Path -LiteralPath $DestinationDirectory)) {
        New-Item -ItemType Directory -Path $DestinationDirectory | Out-Null
    }

    $target = Join-Path $DestinationDirectory ([IO.Path]::GetFileName($Source))
    if (Test-Path -LiteralPath $target) {
        Remove-Item -LiteralPath $target -Force
    }

    Copy-Item -LiteralPath $Source -Destination $target -Force
}

Copy-One -Source (Join-Path $RuntimeSourceRoot "WRobot.exe") -DestinationDirectory $BuildRoot
Copy-One -Source (Join-Path $RuntimeSourceRoot "WRobot.exe.config") -DestinationDirectory $BuildRoot
Copy-One -Source (Join-Path $RuntimeSourceRoot "Bin\RDManaged.dll") -DestinationDirectory $BuildRoot
Copy-One -Source (Join-Path $RuntimeSourceRoot "Bin\fasmdll_managed.dll") -DestinationDirectory $BuildRoot

Get-Item `
    (Join-Path $BuildRoot "WRobot.exe"), `
    (Join-Path $BuildRoot "WRobot.exe.config"), `
    (Join-Path $BuildRoot "RDManaged.dll"), `
    (Join-Path $BuildRoot "fasmdll_managed.dll") |
    Select-Object Name, Length, LastWriteTime
