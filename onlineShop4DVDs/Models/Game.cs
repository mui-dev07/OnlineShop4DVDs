using System;
using System.Collections.Generic;

namespace onlineShop4DVDs.Models;

public partial class Game
{
    public int GameId { get; set; }

    public string Title { get; set; } = null!;

    public int? CategoryId { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public virtual Category? Category { get; set; }
}
