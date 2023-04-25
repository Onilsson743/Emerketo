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
    public string PhoneNumber { get; set; } = null!;

    [Display(Name = "Company (Optional)")]
    public string Company { get; set; } = null!;

    [Display(Name = "E-mail*")]
    [Required(ErrorMessage = "Please fill in your email adress")]
    public string Email { get; set; } = null!;


    [Display(Name = "Password*")]
    [Required(ErrorMessage = "Please fill in a password")]
    public string Password { get; set; } = null!;

    [Display(Name = "Confirm Password*")]
    [Required(ErrorMessage = "Please confirm the password")]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "Upload Profile Image (Optional)")]
    public IFormFile? ImageFile { get; set; }


    [Display(Name = "I have read and accepts the terms and agreements")]
    public bool TermsAndAgreements { get; set; } = false;


}
