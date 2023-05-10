using Ecommerceproject.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ecommerceproject.ViewModels;

public class RegistrationViewModel
{
    [Display(Name = "First Name*")]
    [Required(ErrorMessage = "Please fill in your first name")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last Name*")]
    [Required(ErrorMessage = "Please fill in your last name")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Street Name*")]
    [Required(ErrorMessage = "Please fill in your street name")]
    public string StreetName { get; set; } = null!;

    [Display(Name = "Postal Code*")]
    [Required(ErrorMessage = "Please fill in your postal code")]
    public string PostalCode { get; set; } = null!;

    [Display(Name = "City*")]
    [Required(ErrorMessage = "Please fill in your city")]
    public string City { get; set; } = null!;

    [Display(Name = "Mobile (Optional)")]
    public string? PhoneNumber { get; set; } = null!;

    [Display(Name = "Company (Optional)")]
    public string? Company { get; set; }

    [Display(Name = "E-mail*")]
    [Required(ErrorMessage = "Please fill in your email adress")]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Please provide an valid email adress.")]
    public string Email { get; set; } = null!;


    [Display(Name = "Passwords*")]
    [Required(ErrorMessage = "Please fill in a password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Confirm Password*")]
    [Required(ErrorMessage = "Please confirm the password")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The confirmation password do not match the original password.")]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "Upload Profile Image (Optional)")]
    [DataType(DataType.Upload)]
    public IFormFile? ImageFile { get; set; }


    [Display(Name = "I have read and accepts the terms and agreements")]
    [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to the terms and agreements.")]
    public bool TermsAndAgreements { get; set; } = false;


    public static implicit operator UserEntity(RegistrationViewModel model)
    {
        return new UserEntity
        {
            UserName = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
        };
    }

    public static implicit operator AddressEntity(RegistrationViewModel model)
    {
        return new AddressEntity
        {
            StreetName = model.StreetName,
            PostalCode = model.PostalCode,
            City = model.City,
        };
    }

}
