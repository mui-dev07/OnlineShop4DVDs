using System;
using System.Collections.Generic;

namespace onlineShop4DVDs.Models;

public partial class Producer
{
    public int ProducerId { get; set; }

    public string Name { get; set; } = null!;

    public string? ContactInfo { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
}
