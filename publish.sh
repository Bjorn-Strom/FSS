#!/bin/bash
set -e

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
KEY_FILE="$SCRIPT_DIR/nuget-api-key"

if [ ! -f "$KEY_FILE" ]; then
    echo "Error: nuget-api-key file not found. Paste your API key into: $KEY_FILE"
    exit 1
fi

API_KEY="$(cat "$KEY_FILE" | tr -d '[:space:]')"

if [ -z "$API_KEY" ] || [ "$API_KEY" = "PASTE_YOUR_NUGET_API_KEY_HERE" ]; then
    echo "Error: Paste your actual NuGet API key into: $KEY_FILE"
    exit 1
fi

PROJECTS=(
    "Fss.Core/Fss.Core.fsproj"
    "Fss.Fable/Fss.Fable.fsproj"
    "Fss.Feliz/Fss.Feliz.fsproj"
    "Fss.Giraffe/Fss.Giraffe.fsproj"
    "Fss.Falco/Fss.Falco.fsproj"
    "Fss.Static/Fss.Static.fsproj"
    "Fss.Builder/Fss.Builder.fsproj"
)

echo "=== Packing ==="
for proj in "${PROJECTS[@]}"; do
    echo "Packing $proj..."
    dotnet pack "$SCRIPT_DIR/$proj" -c Release -o "$SCRIPT_DIR/nupkgs"
done

echo ""
echo "=== Pushing ==="
for pkg in "$SCRIPT_DIR"/nupkgs/*.nupkg; do
    echo "Pushing $(basename "$pkg")..."
    dotnet nuget push "$pkg" --api-key "$API_KEY" --source https://api.nuget.org/v3/index.json --skip-duplicate
done

echo ""
echo "Done!"
