#!/bin/bash

set -e

echo "======================================"
echo "  Name Sorter - Global Tool Installer"
echo "======================================"
echo

# Ensure script is run from repo root
if [ ! -d "NameSorter.ConsoleApp" ]; then
    echo "ERROR: This script must be run from the repository root."
    exit 1
fi

echo "[1/4] Cleaning previous build..."
dotnet clean > /dev/null

echo "[2/4] Building solution..."
dotnet build --configuration Release > /dev/null

echo "[3/4] Packing console app as .NET tool..."
mkdir -p tool-packages

dotnet pack ./NameSorter.ConsoleApp/NameSorter.ConsoleApp.csproj \
    --configuration Release \
    --output ./tool-packages > /dev/null

# Find generated .nupkg package
PACKAGE=$(ls ./tool-packages/*.nupkg | head -n 1)

if [ -z "$PACKAGE" ]; then
    echo "ERROR: No .nupkg file found in tool-packages folder!"
    exit 1
fi

echo "Package located:"
echo "  $PACKAGE"
echo

echo "[4/4] Installing or updating global tool..."

# Uninstall any previous version
dotnet tool uninstall --global name-sorter >/dev/null 2>&1 || true

# Install new tool from local source
dotnet tool install --global name-sorter --add-source ./tool-packages

echo
echo "======================================"
echo "   Installation Complete Successfully"
echo "======================================"
echo
echo "You can now run the tool anywhere using:"
echo
echo "   name-sorter ./unsorted-names-list.txt"
echo
