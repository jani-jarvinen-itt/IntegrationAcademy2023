using System.Linq;
using System.Xml.Linq;

XDocument dokumentti = XDocument.Load(@"..\..\..\Northwind.xml");
Console.WriteLine("XML-dokumentti ladattu.");

string igTunnus = HaeAsiakkaanLisätiedot("ALFKI");
Console.WriteLine(igTunnus);

string lisätiedot = HaeTilauksenLisätiedot(10248);
Console.WriteLine(lisätiedot);

string HaeAsiakkaanLisätiedot(string asikasId)
{
    var asiakasElementit = dokumentti.Descendants("Customer");

    XElement? asiakas = asiakasElementit.FirstOrDefault(
        c => c.Element("CustomerID")?.Value == asikasId);
    if (asiakas != null)
    {
        string igTunnus = asiakas.Element("SocialMedia")?.Element("Instagram")?.Value ?? "";
        return igTunnus;
    }
    else
    {
        return "";
    }
}

string HaeTilauksenLisätiedot(int tilausNro)
{
    var tilausElementit = dokumentti.Descendants("Order");

    XElement? tilaus = tilausElementit.FirstOrDefault(
        c => int.Parse(c.Element("OrderID")?.Value ?? "0") == tilausNro);
    if (tilaus != null)
    {
        string lisätiedot = tilaus.Element("SpecialInstructions")?.Value ?? "";
        return lisätiedot;
    }
    else
    {
        return "";
    }
}