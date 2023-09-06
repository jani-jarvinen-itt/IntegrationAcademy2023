using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing
{
    public class OmanKomennonKäsittelijä :
        IHandleMessages<OmaKomento>
    {
        static readonly ILog log = LogManager.GetLogger<OrderPlacedHandler>();

        public Task Handle(OmaKomento message, IMessageHandlerContext context)
        {
            log.Info("OmaKomento on saapunut, tiedot: " +
                $"{message.Ominaisuus1}, {message.Ominaisuus2}.");

            return Task.CompletedTask;
        }
    }
}
