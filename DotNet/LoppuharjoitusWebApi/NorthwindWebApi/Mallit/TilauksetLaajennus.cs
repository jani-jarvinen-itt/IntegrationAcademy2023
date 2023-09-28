using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindWebApi.Entities
{
    public partial class Order
    {
        [NotMapped]
        public string KäsittelyOhjeet { get; set; }
    }
}
