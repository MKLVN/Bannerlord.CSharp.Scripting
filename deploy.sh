#!/bin/bash

# Deployment script for C# Scripting mod
# Usage: ./deploy.sh

# Set your Bannerlord path here or pass as argument
BANNERLORD_PATH="/mnt/c/Program Files (x86)/Steam/steamapps/common/Mount & Blade II Bannerlord"
MOD_NAME="CSharpScripting"
MOD_DIR="$BANNERLORD_PATH/Modules/$MOD_NAME"

echo "Deploying C# Scripting mod to: $MOD_DIR"

# Check if Bannerlord directory exists
if [ ! -d "$BANNERLORD_PATH" ]; then
    echo "Error: Bannerlord directory not found at: $BANNERLORD_PATH"
    echo "Please provide the correct path as an argument:"
    echo "  ./deploy.sh '/path/to/Mount & Blade II Bannerlord'"
    exit 1
fi

# Create mod directory
mkdir -p "$MOD_DIR"
mkdir -p "$MOD_DIR/bin/Win64_Shipping_Client"

# Copy SubModule.xml
echo "Copying SubModule.xml..."
cp "_Module/SubModule.xml" "$MOD_DIR/"

# Copy DLL and dependencies
echo "Copying binaries..."
cp bin/x64/Release/net472/*.dll "$MOD_DIR/bin/Win64_Shipping_Client/"

# Copy Scripts to both locations (mod root and DLL directory)
echo "Copying scripts..."
cp -r "Scripts" "$MOD_DIR/"
cp -r "Scripts" "$MOD_DIR/bin/Win64_Shipping_Client/"

echo "Deployment complete!"
echo "Mod installed to: $MOD_DIR"
echo ""
echo "Next steps:"
echo "1. Launch Bannerlord"
echo "2. Enable 'C# Scripting' mod in the launcher"
echo "3. Start a campaign and test with Alt+~ console"