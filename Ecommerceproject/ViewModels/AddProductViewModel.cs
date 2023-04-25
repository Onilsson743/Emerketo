using System.ComponentModel.DataAnnotations;

namespace Ecommerceproject.ViewModels
{
    public class AddProductViewModel
    {
        [Display(Name = "Product Name*")]
        [Required(ErrorMessage = "A product name is required")]
        public string ProductName { get; set; } = null!;

        [Display(Name = "Price*")]
        [Required(ErrorMessage = "A price is required")]
        public decimal Price { get; set; }

        [Display(Name = "Category*")]
        [Required(ErrorMessage = "Atleast one category is required")]
        public List<string> ProductCategory { get; set; } = null!;

        [Display(Name = "Image Url*")]
        [Required(ErrorMessage = "A url for the product image is required")]
        public string ProductImageUrl { get; set; } = null!;

        [Display(Name = "Description*")]
        [Required(ErrorMessage = "A description is required")]
        public string ProductDescription { get; set; } = null!;
        public List<string> Colours { get; set; } = new List<string>();

        [Display(Name = "Quantity in stock")]
        public int ProductInStock { get; set; }
    }
}
