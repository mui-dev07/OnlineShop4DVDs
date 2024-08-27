﻿using System.ComponentModel.DataAnnotations;

namespace onlineShop4DVDs.Models
{
    public class loginView
    {

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
