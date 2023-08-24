using System.Xml;

XmlDocument palkkatiedot = new();
palkkatiedot.Load(@"..\..\..\Palkanlaskenta.xml");
Console.WriteLine("XML-tiedosto ladattu.");

XmlNode juuri = palkkatiedot.DocumentElement;

for (int i = 0; i < juuri.ChildNodes.Count; i++)
{
    // Console.WriteLine(juuri.ChildNodes[i].InnerText);
    string palkka = juuri.ChildNodes[i].ChildNodes[0].InnerText;
    string nimi = juuri.ChildNodes[i].ChildNodes[1].InnerText;

    Console.WriteLine($"Nimi: {nimi}, palkka: {palkka}");
}

Console.WriteLine("Loppu.");
