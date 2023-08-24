using PalkanlaskentaDataMuunnos;
using System.Xml;

XmlDocument palkkatiedot = new();
palkkatiedot.Load(@"..\..\..\Palkanlaskenta.xml");
Console.WriteLine("XML-tiedosto ladattu.");

XmlNode juuri = palkkatiedot.DocumentElement;
List<PalkkaTietomalli> tulokset = new();

for (int i = 0; i < juuri.ChildNodes.Count; i++)
{
    // Console.WriteLine(juuri.ChildNodes[i].InnerText);
    string palkka = juuri.ChildNodes[i].ChildNodes[0].InnerText;
    string nimi = juuri.ChildNodes[i].ChildNodes[1].InnerText;

    Console.WriteLine($"Nimi: {nimi}, palkka: {palkka}");

    tulokset.Add(new PalkkaTietomalli()
    {
        personName = nimi,
        salary = new Salary()
        {
            monthly = float.Parse(palkka)
        }
    });
}

Console.WriteLine("----------------");
string json = System.Text.Json.JsonSerializer.Serialize(tulokset);
Console.WriteLine(json);
Console.WriteLine("----------------");


Console.WriteLine("Loppu.");
