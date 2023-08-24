using PalkanlaskentaDataMuunnos;
using System.Globalization;
using System.Xml;

XmlDocument palkkatiedot = new();
palkkatiedot.Load(@"..\..\..\Palkanlaskenta.xml");
Console.WriteLine("XML-tiedosto ladattu.");

XmlNode juuri = palkkatiedot.DocumentElement;
List<PalkkaTietomalli> tulokset = new();

float usdKurssi = LueUsdKurssi();

for (int i = 0; i < juuri.ChildNodes.Count; i++)
{
    // Console.WriteLine(juuri.ChildNodes[i].InnerText);
    XmlNode lapsi = juuri.ChildNodes[i];
    string palkka = lapsi.ChildNodes[0].InnerText;
    string nimi = lapsi.ChildNodes[1].InnerText;
    string henkilöId = lapsi.Attributes["henkilöstöid"]?.Value;

    Console.WriteLine($"Nimi: {nimi}, palkka: {palkka}");
    Console.WriteLine($"   Henkilöstö-id: {henkilöId}");

    tulokset.Add(new PalkkaTietomalli()
    {
        personName = nimi,
        salary = new Salary()
        {
            monthly = float.Parse(palkka) * usdKurssi
        }
    });
}

Console.WriteLine("----------------");
string json = System.Text.Json.JsonSerializer.Serialize(tulokset);
Console.WriteLine(json);
Console.WriteLine("----------------");


Console.WriteLine("Loppu.");


float LueUsdKurssi()
{
    XmlDocument valuuttakurssit = new();
    valuuttakurssit.Load(@"..\..\..\Valuuttakurssi.xml");

    XmlNode juuri = valuuttakurssit.DocumentElement;
    XmlNode kuutio = juuri.ChildNodes[2].ChildNodes[0].ChildNodes[0];

    string usdKurssi = kuutio.Attributes["rate"].Value;
    Console.WriteLine("USD-kurssi:");
    Console.WriteLine(usdKurssi);

    CultureInfo enUs = new("en-US");
    return float.Parse(usdKurssi, enUs);
}