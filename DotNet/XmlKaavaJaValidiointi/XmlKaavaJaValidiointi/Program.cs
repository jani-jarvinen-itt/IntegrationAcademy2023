using System.Xml;
using System.Xml.Schema;

XmlReaderSettings settings = new();
settings.Schemas.Add(null,
    @"..\..\..\Kirjat-kaavatiedosto.xsd");
settings.ValidationType = ValidationType.Schema;
settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

XmlReader reader = XmlReader.Create(
    @"..\..\..\Kirjat.xml", settings);
XmlDocument document = new();
document.Load(reader);

ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);

Console.WriteLine("XML-validiointi alkaa.");
document.Validate(eventHandler);
Console.WriteLine("XML-validiointi on päättynyt.");

void ValidationEventHandler(object sender, ValidationEventArgs e)
{
    switch (e.Severity)
    {
        case XmlSeverityType.Error:
            Console.WriteLine("Error: {0}", e.Message);
            break;
        case XmlSeverityType.Warning:
            Console.WriteLine("Warning {0}", e.Message);
            break;
    }
}