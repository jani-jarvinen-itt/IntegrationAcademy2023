using log4net;
using log4net.Config;

ILog log = LogManager.GetLogger(typeof(Program));
BasicConfigurator.Configure();

log.Info("Testi-ilmoitus.");

try
{
	throw new InvalidOperationException("Pöö!");
}
catch (Exception ex)
{
	log.Error("Odottamaton virhe!", ex);
}