using System;
using System.Collections.Generic;

namespace onlineShop4DVDs.Models;

public partial class Album
{
    public int AlbumId { get; set; }

    public string Title { get; set; } = null!;

    public DateOnly? ReleaseDate { get; set; }

    public int? ArtistId { get; set; }

    public int? ProducerId { get; set; }

    public int? CategoryId { get; set; }

    public string? AlbumPicture { get; set; }

    public virtual Artist? Artist { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Producer? Producer { get; set; }

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
