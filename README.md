# bitwarden-protonpass-processor
As of March 1st 2025, the Windows Proton Pass application does not import custom Bitwarden fields when importing a Bitwarden export file.
This results in loosing all custom fields the user might have used in Bitwarden when migrating from Bitwarden to Proton Pass.

The approach chosen in this program is to add in the Notes section one line per each custom field, containing the field name and its value.

It was tested only with custom fields of type Text.

## Usage:
1. Modify the *str_BitwardenExportFile* path in Program.cs to point to your Bitwarden export file
2. Run the program
  
## Requirements:
- .NET 9.0 (albeit the classes used inside are most probably available in older .NET versions)
