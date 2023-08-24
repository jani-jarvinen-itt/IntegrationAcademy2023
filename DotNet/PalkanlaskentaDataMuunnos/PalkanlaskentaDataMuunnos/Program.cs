using PalkanlaskentaDataMuunnos;
using System.Xml;

XmlDocument palkkatiedot = new();
palkkatiedot.Load(@"..\..\..\Palkanlaskenta.xml");
Console.WriteLine("XML-tiedosto ladattu.");

XmlNode juuri = palkkatiedot.DocumentElement;
List<PalkkaTietomalli> tulokset = new();

float usdKurssi = 1.1313f;

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
