# Separated 7-Zip Compression Utility
A small utility to compress files to a list of 7-Zip archives individually

## System Requirements
* .NET Framework 2.0
* 7-Zip for Windows (Download at https://www.7-zip.org/)

[Runtime configuration](https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-configure-an-app-to-support-net-framework-4-or-4-5) is needed for running in .NET Framework 4.0+.

## Usage
```
Separated7zCompressionUtility [/nodel] <Directory> <Search Pattern>
```
* **\<Directory\>** - The directory containing files to be compressed
* **\<Search Pattern\>** - The search pattern to pick specific files (for example, *.txt, *.*, etc.)
* **/nodel** - Do not delete original files (the default behavior is to delete all original files after compression)

## Development Prerequisites
* Visual Studio 2015+

Before the build, generate-build-number.sh needs to be executed in a Git / Bash shell to generate build information code file (BuildInfo.cs).
