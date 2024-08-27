using System;
using System.Collections.Generic;

namespace onlineShop4DVDs.Models;

public partial class UserCred
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string? ProfilePicture { get; set; }

    public string Password { get; set; } = null!;

    public DateTime? DateTime { get; set; }
}
