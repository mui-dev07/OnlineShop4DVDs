using System;
using System.Collections.Generic;

namespace onlineShop4DVDs.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public int? TotalAmount { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
