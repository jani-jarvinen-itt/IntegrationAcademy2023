﻿using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindWebApi.Entities
{
    public partial class Customer
    {
        [NotMapped]
        public string? InstagramTunnus { get; set; }
    }
}
