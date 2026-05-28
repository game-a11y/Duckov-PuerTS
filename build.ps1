param(
    [ValidateSet('Debug', 'Release')]
    [string]$Configuration = 'Release'
)

$ProjectDir = Join-Path $PSScriptRoot 'PuerTS'

Write-Host "Building PuerTS ($Configuration)..." -ForegroundColor Cyan

dotnet build "$ProjectDir\PuerTS.sln" -c $Configuration -nologo

if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed!" -ForegroundColor Red
    exit $LASTEXITCODE
}

Write-Host "Build succeeded." -ForegroundColor Green
