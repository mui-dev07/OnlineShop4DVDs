using System;
using System.Collections.Generic;

namespace onlineShop4DVDs.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int? UserId { get; set; }

    public string? Content { get; set; }

    public DateOnly? FeedbackDate { get; set; }
}
