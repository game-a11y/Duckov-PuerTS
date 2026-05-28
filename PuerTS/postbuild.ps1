param(
    [string]$ProjectDir,
    [string]$TargetDir
)

Write-Host "Copying Assets to Release Dir"

# Copy Runtime files
if (Test-Path "$ProjectDir\upm\Editor\Resources") {
    Copy-Item "$ProjectDir\upm\Editor\Resources\*" "$ProjectDir\PuerTS\upm\Editor\Resources\" -Recurse -Force
}
Copy-Item "$ProjectDir\upm\Runtime\Resources\*" "$ProjectDir\PuerTS\upm\Runtime\Resources\" -Recurse -Force
Copy-Item "$ProjectDir\Scripts\*" "$ProjectDir\PuerTS\Scripts\" -Recurse -Force
Copy-Item "$ProjectDir\upm\LICENSE" "$ProjectDir\PuerTS\upm\" -Force
Copy-Item "$ProjectDir\upm\package.json" "$ProjectDir\PuerTS\upm\" -Force
Copy-Item "$ProjectDir\upm\Plugins\x86_64\*.dll" "$ProjectDir\PuerTS\" -Force

# Copy MOD dll
Copy-Item "$TargetDir\PuerTS.dll" "$ProjectDir\PuerTS\" -Force
Copy-Item "$TargetDir\PuerTS.pdb" "$ProjectDir\PuerTS\" -Force
Copy-Item "$TargetDir\PuerTS.deps.json" "$ProjectDir\PuerTS\" -Force
Copy-Item "$TargetDir\PuerTSRuntime.dll" "$ProjectDir\PuerTS\" -Force
Copy-Item "$TargetDir\PuerTSRuntime.pdb" "$ProjectDir\PuerTS\" -Force

# Copy mod meta files
$RepoRoot = Join-Path $ProjectDir '..'
Copy-Item "$ProjectDir\info.ini" "$ProjectDir\PuerTS\" -Force
Copy-Item "$ProjectDir\preview.png" "$ProjectDir\PuerTS\" -Force
Copy-Item "$RepoRoot\LICENSE" "$ProjectDir\PuerTS\" -Force
Copy-Item "$RepoRoot\README.md" "$ProjectDir\PuerTS\" -Force
