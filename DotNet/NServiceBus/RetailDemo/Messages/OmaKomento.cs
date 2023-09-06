using NServiceBus;

namespace Messages
{
    public class OmaKomento : ICommand
    {
        public string Ominaisuus1 { get; set; }

        public string Ominaisuus2 { get; set; }
    }
}
