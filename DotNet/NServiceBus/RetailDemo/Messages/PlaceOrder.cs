using NServiceBus;

namespace Messages
{
    public class PlaceOrder : ICommand
    {
        public string OrderId { get; set; }

        public string CustomerName { get; set; }

        public float OrderAmount { get; set; }
    }
}