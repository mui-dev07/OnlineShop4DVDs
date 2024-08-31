using System;
using System.Collections.Generic;

namespace onlineShop4DVDs.Models;

public partial class ContactMessage
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Message { get; set; } = null!;

    public DateTime? SubmittedDate { get; set; }
}
