using System.Xml.Schema;
using System.Xml;

const string SisäänlukuKansio = @"C:\Integration\Demo\Input";
const string KäsitellytKansio = @"C:\Integration\Demo\Processed";
const string VirheetKansio = @"C:\Integration\Demo\Errors";

string[] tiedostot = Directory.GetFiles(SisäänlukuKansio, "*.xml");

if (tiedostot.Length > 0)
{
    foreach (string tiedosto in tiedostot)
    {
        // XML-validiointi
        bool ok = ValidioiXmlTiedosto(tiedosto);

        // tiedoston siirto oikeaan kansioon
        string nimi = Path.GetFileName(tiedosto);
        if (ok)
        {
            string kohdePolku = Path.Combine(KäsitellytKansio, nimi);
            File.Move(tiedosto, kohdePolku);
        }
        else
        {
            string kohdePolku = Path.Combine(VirheetKansio, nimi);
            File.Move(tiedosto, kohdePolku);
        }

        Console.WriteLine("Käsitelty tiedosto: " + tiedosto);
    }
}

bool ValidioiXmlTiedosto(string tiedosto)
{
    bool tulos = false;

    XmlReaderSettings settings = new();
    settings.Schemas.Add(null,
        @"..\..\..\Kirjat-kaavatiedosto.xsd");
    settings.ValidationType = ValidationType.Schema;
    settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

    XmlReader reader = XmlReader.Create(tiedosto, settings);
    XmlDocument document = new();
    document.Load(reader);

    ValidationEventHandler eventHandler = new(ValidationEventHandler);

    Console.WriteLine("XML-validiointi alkaa.");
    document.Validate(eventHandler);
    Console.WriteLine("XML-validiointi on päättynyt.");

    // suljetaan tiedosto
    reader.Close();

    tulos = true;
    return tulos;
}

void ValidationEventHandler(object sender, ValidationEventArgs e)
{
    switch (e.Severity)
    {
        case XmlSeverityType.Error:
            Console.WriteLine("XML-virhe: {0}", e.Message);
            break;
        case XmlSeverityType.Warning:
            Console.WriteLine("XML-varoitus {0}", e.Message);
            break;
    }
}