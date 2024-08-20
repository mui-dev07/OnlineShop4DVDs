using System;
using System.Collections.Generic;

namespace onlineShop4DVDs.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string Name { get; set; } = null!;

    public string? ContactInfo { get; set; }
}
