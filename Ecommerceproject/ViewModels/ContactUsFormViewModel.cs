using System.ComponentModel.DataAnnotations;

namespace Ecommerceproject.ViewModels;

public class ContactUsFormViewModel
{
    [Display(Name = "Your Name*")]
    [Required(ErrorMessage = "Your name is required")]
    public string Name { get; set; } = null!;

    [Display(Name = "Your Email*")]
    [Required(ErrorMessage = "An Email is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; } = null!;
    public string? Company { get; set; } = null!;

    [Display(Name = "Message*")]
    [Required(ErrorMessage = "A Message is required")]
    public string Message { get; set; } = null!;


    [Display(Name = "Save my name, email, and website in this browser for the next time I comment")]
    public bool TermsAndAgreements { get; set; } = false;
}
