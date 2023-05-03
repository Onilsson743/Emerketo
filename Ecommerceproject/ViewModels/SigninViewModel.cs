﻿using System.ComponentModel.DataAnnotations;

namespace Ecommerceproject.ViewModels;

public class SigninViewModel
{
    [Display(Name = "E-Mail*")]
    [Required(ErrorMessage = "You must provide an e-mail")]
    public string Email { get; set; } = null!;

    [Display(Name = "Password*")]
    [Required(ErrorMessage = "You must provide a password")]
    public string Password { get; set; } = null!;

    [Display(Name = "Please keep me logged in")]
    public bool KeepMeSignedIn { get; set; }
}
