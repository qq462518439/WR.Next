$ErrorActionPreference = 'Stop'

$root = 'D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48'
$bin = $root
$hostExe = Join-Path $root 'WR.OriginalUiHost.exe'
$wow = Get-Process Wow -ErrorAction Stop | Select-Object -First 1
$pidValue = $wow.Id

[AppDomain]::CurrentDomain.add_AssemblyResolve({
    param($sender, $args)
    $name = ([Reflection.AssemblyName]::new($args.Name)).Name + '.dll'
    foreach ($dir in @($bin, $root, (Join-Path $root 'Products'), (Join-Path $root 'FightClass')))
    {
        $path = Join-Path $dir $name
        if ([IO.File]::Exists($path))
        {
            return [Reflection.Assembly]::LoadFrom($path)
        }
    }

    return $null
})

$env:WR_RUNTIME_ROOT = $root
$asm = [Reflection.Assembly]::LoadFrom($hostExe)
$type = $asm.GetType('WR.OriginalUiHost.OriginalRuntimeBootstrap', $true)
$instance = [Activator]::CreateInstance($type, @($root))
$method = $type.GetMethod('AttachToWowProcess')
$result = $method.Invoke($instance, @($pidValue))
Start-Sleep -Seconds 8

$resultType = $result.GetType()
$ok = $resultType.GetProperty('Ok').GetValue($result, $null)
$message = $resultType.GetProperty('Message').GetValue($result, $null)

Write-Output ('PID=' + $pidValue)
Write-Output ('OK=' + $ok)
Write-Output ('MSG=' + $message)
