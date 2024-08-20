using System;
using System.Collections.Generic;

namespace onlineShop4DVDs.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? Role { get; set; }

    public int? ProfileId { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Profile? Profile { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
