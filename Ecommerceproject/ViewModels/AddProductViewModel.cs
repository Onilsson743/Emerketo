using Ecommerceproject.Models;
using System.ComponentModel.DataAnnotations;

namespace Ecommerceproject.ViewModels
{
    public class AddProductViewModel
    {
        [Display(Name = "Product Name*")]
        [Required(ErrorMessage = "A Product Name is required")]
        public string ProductName { get; set; } = null!;

        [Display(Name = "Price*")]
        [Required(ErrorMessage = "A Product Price is required")]
        public decimal Price { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "A Product Name is required")]
        public string ProductDescription { get; set; } = null!;

        [Display(Name = "Categories")]
        public List<string> ProductCategory { get; set; } = null!;

        [Display(Name = "Current amount in stock*")]
        [Required(ErrorMessage = "You must set an amount in stock")]
        public int ProductInStock { get; set; }

        [Display(Name = "Image URL*")]
        [Required(ErrorMessage = "An image URL is required")]
        public string ProductImageUrl { get; set; } = null!;

        public List<string> Colours { get; set; } = new List<string>();
        public List<CheckBox> ColoursList { get; set; } = new List<CheckBox>();

    }
}
