using System;
using System.Collections.Generic;

namespace EntityFrameworkWebApi.Models;

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}
