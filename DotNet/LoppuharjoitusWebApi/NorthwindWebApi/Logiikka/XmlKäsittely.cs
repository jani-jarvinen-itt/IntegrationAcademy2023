using System.Xml.Linq;

namespace NorthwindWebApi.Logiikka
{
    public class XmlKäsittely
    {
        protected XDocument XmlDokumentti { get; set; }

        public XmlKäsittely()
        {
            XmlDokumentti = XDocument.Load(@"Northwind.xml");
        }

        public string HaeAsiakkaanLisätiedot(string asikasId)
        {
            var asiakasElementit = XmlDokumentti.Descendants("Customer");

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

        public string HaeTilauksenLisätiedot(int tilausNro)
        {
            var tilausElementit = XmlDokumentti.Descendants("Order");

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
    }
}
