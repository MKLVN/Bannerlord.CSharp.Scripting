# Bannerlord C# Scripting Mod - Compatibility Update v1.4.0

## Overview
This mod has been successfully updated from **e1.7.x (Early Access)** to **v1.2.x (Current)** compatibility.

## What's New in v1.4.0
- ✅ **Full Bannerlord v1.2.x compatibility**
- ✅ **Modernized build system** (updated packages, assembly references)
- ✅ **Enhanced logging** (automatic command logging for debugging)
- ✅ **Improved error handling** (better error messages, graceful recovery)
- ✅ **Fixed reset functionality** (properly clears Shared object)
- ✅ **Hot reload confirmed working** (script changes apply immediately)

## Verified Working Features
- ✅ All console commands (`csx.eval`, `csx.run`, `csx.list`, `csx.help`, `csx.reset`)
- ✅ Game API integration (`Me`, `Heroes`, `Settlements`, `MyClan` shortcuts)
- ✅ Script file system (pre-built .csx scripts with hot reload)
- ✅ Game state modification (gold changes, party info access)
- ✅ Lookup system (`Heroes['name']`, `Settlements['name']`)
- ✅ Error handling (graceful recovery, clear messages)
- ✅ State persistence (`Shared` object for persistent storage)
- ✅ Logging redirection (`csx.log_to` for script output)

## Technical Notes
- **Quote syntax:** Use single quotes for lookups (`Heroes['Derthert']`)
- **Expressions vs statements:** `csx.eval` expects expressions, use `Shared` for persistence
- **Performance:** Complex operations complete in 1-2 seconds
- **Logging:** Commands automatically logged to `ProgramData/Mount and Blade II Bannerlord/logs/`

## Installation
1. Download/build the mod
2. Copy to `Bannerlord/Modules/CSharpScripting/`
3. Enable in Bannerlord launcher
4. Use `Alt + ~` to open console and try `csx.help`

## Compatibility
- **Bannerlord version:** v1.2.x (tested on v1.2.12)
- **Framework:** .NET Framework 4.7.2
- **Dependencies:** All updated to compatible versions

## Credits
Original mod by int19h. Compatibility update by MKLVN completed July 2025.