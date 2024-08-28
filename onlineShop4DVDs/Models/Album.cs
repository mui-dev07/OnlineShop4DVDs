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

    public virtual ICollection<Artist> Artists { get; set; }

    public virtual ICollection<Category> Categories { get; set; }

    public virtual Producer? Producer { get; set; }

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
