using System.Xml.Xsl;

Console.WriteLine("XSLT-muunnos käynnistyy.");

// Load the style sheet.
XslCompiledTransform xslt = new();
xslt.Load(@"..\..\..\Kirjat.xslt");

// Execute the transform and output the results to a file.
xslt.Transform(@"..\..\..\Kirjat.xml", "Kirjat-tuloste.html");

Console.WriteLine("XSLT-muunnos valmis.");
