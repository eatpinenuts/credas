Write-Host "=== Building NameSorter Console Tool ==="

# Build the solution
dotnet clean
dotnet build --configuration Release

Write-Host "=== Packing NuGet Tool Package ==="

# Pack the tool
dotnet pack .\NameSorter.ConsoleApp\NameSorter.ConsoleApp.csproj `
    --configuration Release `
    --output .\tool-packages

if (!(Test-Path .\tool-packages)) {
    Write-Error "Package folder not found!"
    exit 1
}

# Find the .nupkg file
$package = Get-ChildItem .\tool-packages\*.nupkg | Select-Object -First 1

if ($null -eq $package) {
    Write-Error "No .nupkg package found!"
    exit 1
}

Write-Host "=== Installing Global .NET Tool ==="
Write-Host "Package: $($package.FullName)"

# Uninstall existing tool if installed
dotnet tool uninstall --global name-sorter 2>$null

# Install using local folder as feed
dotnet tool install --global name-sorter --add-source .\tool-packages

Write-Host "`n=== Installation Complete ==="
Write-Host "You can now run: name-sorter ./unsorted-names-list.txt"
