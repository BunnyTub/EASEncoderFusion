$folderPath = Get-Location

Get-ChildItem -Path $folderPath | ForEach-Object {
    $filePath = $_.FullName
    if (Test-Path "$filePath:Zone.Identifier") {
        Remove-Item "$filePath:Zone.Identifier" -Force
        Write-Host "Removed Zone Identifier from $filePath"
    } else {
        Write-Host "No Zone Identifier found for $filePath"
    }
}
