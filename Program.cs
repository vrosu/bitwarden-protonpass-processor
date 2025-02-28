using System.Text.Json;
using System.Text.Json.Nodes;

String str_BitwardenExportFile = "E:\\bitwarden_export_20250226225203.json";
String str_BitwardenExportProcessedFile = "E:\\bitwarden_export_processed" + System.DateTime.Now.ToString("HH-mm-ss") + ".json";
String str_BitwardenExportContent = File.ReadAllText(str_BitwardenExportFile);
JsonNode json_Bitwarden = JsonNode.Parse(str_BitwardenExportContent);
JsonNode json_Items = json_Bitwarden["items"];

int int_FieldCount = 0;
foreach (JsonNode Item in json_Items.AsArray())
{
    string str_Note = (string)Item["notes"];
    JsonNode json_Fields= Item["fields"];
    if (json_Fields != null)
    {
        int_FieldCount++;
        foreach (JsonNode field in json_Fields.AsArray())
        {
            Item["notes"] = (string)Item["notes"] +"\n"+field["name"] + "|" + (((string)field["value"]) != null ? field["value"]:"-");
        }
        //marking it null so that Proton Pass would not detect and warn it was not able to import the entry correctly
        Item["fields"] = null;
    }
}
File.WriteAllText(str_BitwardenExportProcessedFile, json_Bitwarden.ToString());

Console.WriteLine("Found: " + json_Items.AsArray().Count+" entries, from which "+ int_FieldCount+ " entries contained at least one custom field.");