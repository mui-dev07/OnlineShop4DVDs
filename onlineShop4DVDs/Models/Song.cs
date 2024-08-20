﻿using System;
using System.Collections.Generic;

namespace onlineShop4DVDs.Models;

public partial class Song
{
    public int SongId { get; set; }

    public string Title { get; set; } = null!;

    public int? AlbumId { get; set; }

    public TimeOnly? Duration { get; set; }

    public virtual Album? Album { get; set; }
}