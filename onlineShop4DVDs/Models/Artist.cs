using System;
using System.Collections.Generic;

namespace onlineShop4DVDs.Models;

public partial class Artist
{
    public int ArtistId { get; set; }

    public string Name { get; set; } = null!;

    public string? Bio { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
}
