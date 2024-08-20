using System;
using System.Collections.Generic;

namespace onlineShop4DVDs.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public string? Content { get; set; }

    public decimal? Rating { get; set; }

    public DateOnly? ReviewDate { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
