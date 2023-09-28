using System.Text.Json.Serialization;

namespace NorthwindWebApi.Entities
{
    public class CustomerLaajennus: Customer
    {
        public string? InstagramTunnus { get; set; }
    }
}
