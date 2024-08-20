using System;
using System.Collections.Generic;

namespace onlineShop4DVDs.Models;

public partial class Profile
{
    public int ProfileId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public decimal? Balance { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
