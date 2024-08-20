using System;
using System.Collections.Generic;

namespace onlineShop4DVDs.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int? CategoryId { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public decimal? Price { get; set; }

    public decimal? Rating { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
