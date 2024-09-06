using System;
using System.Collections.Generic;

namespace onlineShop4DVDs.Models;

public partial class News
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int? CategoryId { get; set; }

    public string? NewsPicture { get; set; }

    public DateTime? PublishedAt { get; set; }

    public virtual Category? Category { get; set; }
}
