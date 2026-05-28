param(
    [string]$Version,
    [ValidateSet('Debug', 'Release')]
    [string]$Configuration = 'Release'
)

$RepoRoot = $PSScriptRoot
$ModDir = Join-Path $RepoRoot 'PuerTS' 'PuerTS'

# Step 1: Build
& "$RepoRoot\build.ps1" -Configuration $Configuration
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

# Step 2: Resolve version from info.ini if not specified
if (-not $Version) {
    $iniPath = Join-Path $RepoRoot 'PuerTS' 'info.ini'
    $ini = Get-Content $iniPath
    $versionMatch = $ini | Select-String 'displayName.*V(\d+\.\d+)'
    if ($versionMatch) {
        $Version = $versionMatch.Matches[0].Groups[1].Value
    } else {
        $Version = '0.0'
    }
}

# Step 3: Get date and git hash
$DateStr = Get-Date -Format 'yyyyMMdd'
$GitHash = & git -C $RepoRoot rev-parse --short HEAD

# Step 4: Package
$ZipName = "PuerTSMod-v${Version}-${DateStr}+${GitHash}.zip"
$ZipPath = Join-Path $RepoRoot $ZipName

if (Test-Path $ZipPath) {
    Remove-Item $ZipPath
}

Write-Host "Packaging $ModDir to $ZipName ..." -ForegroundColor Cyan

Compress-Archive -Path "$ModDir\*" -DestinationPath $ZipPath

Write-Host "Package created: $ZipPath" -ForegroundColor Green
