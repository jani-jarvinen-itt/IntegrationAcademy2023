const string SisäänlukuKansio = @"C:\Integration\Demo\Input";
const string KäsitellytKansio = @"C:\Integration\Demo\Processed";

string[] tiedostot = Directory.GetFiles(SisäänlukuKansio, "*.xml");

if (tiedostot.Length > 0)
{
    foreach (string tiedosto in tiedostot)
    {
        // TODO: tähän XML-validiointi
        string nimi = Path.GetFileName(tiedosto);
        string kohdePolku = Path.Combine(KäsitellytKansio, nimi);
        File.Move(tiedosto, kohdePolku);
    }
}
