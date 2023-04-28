using System;
using System.Text.Json;
using System.Xml;

public static class JsonToXmlConverter
{
    public static XmlDocument Convert(string json)
    {
        // Parse JSON into a JsonDocument object
        JsonDocument jsonDoc = JsonDocument.Parse(json);

        // Create a new XML document
        XmlDocument xmlDoc = new XmlDocument();

        // Create the root XML element
        XmlElement rootElement = xmlDoc.CreateElement("root");
        xmlDoc.AppendChild(rootElement);

        // Recursively convert JSON to XML
        ConvertJsonToXml(jsonDoc.RootElement, rootElement, xmlDoc);

        // Return the XML as a string
        //return xmlDoc.InnerXml;
        return xmlDoc;
    }

    private static void ConvertJsonToXml(JsonElement jsonElement, XmlElement parentElement, XmlDocument xmlDoc)
    {
        switch (jsonElement.ValueKind)
        {
            case JsonValueKind.Object:
                // Create a new XML element for the object
                XmlElement objectElement = xmlDoc.CreateElement("object");
                parentElement.AppendChild(objectElement);

                // Recursively convert each property to XML
                foreach (JsonProperty property in jsonElement.EnumerateObject())
                {
                    XmlElement propertyElement = xmlDoc.CreateElement(property.Name);
                    objectElement.AppendChild(propertyElement);
                    ConvertJsonToXml(property.Value, propertyElement, xmlDoc);
                }
                break;

            case JsonValueKind.Array:
                // Create a new XML element for the array
                XmlElement arrayElement = xmlDoc.CreateElement("array");
                parentElement.AppendChild(arrayElement);

                // Recursively convert each element to XML
                foreach (JsonElement element in jsonElement.EnumerateArray())
                {
                    ConvertJsonToXml(element, arrayElement, xmlDoc);
                }
                break;

            case JsonValueKind.String:
                // Create a new XML text node for the string
                parentElement.InnerText = jsonElement.GetString();
                break;

            case JsonValueKind.Number:
                // Create a new XML text node for the number
                parentElement.InnerText = jsonElement.GetDouble().ToString();
                break;

            case JsonValueKind.True:
            case JsonValueKind.False:
                // Create a new XML text node for the boolean
                parentElement.InnerText = jsonElement.GetBoolean().ToString().ToLower();
                break;

            case JsonValueKind.Null:
                // Do nothing for null values
                break;

            default:
                throw new ArgumentException($"Invalid JSON value kind: {jsonElement.ValueKind}");
        }
    }

}
