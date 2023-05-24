using Ecommerceproject.Models;
using Ecommerceproject.Models.Entities;
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
        public List<CheckBoxModel> ProductCategory { get; set; } = new List<CheckBoxModel>();

        [Display(Name = "Current amount in stock*")]
        [Required(ErrorMessage = "You must set an amount in stock")]
        public int ProductInStock { get; set; }

        [Display(Name = "Image*")]
        [DataType(DataType.Upload)]
        public IFormFile[]? ProductImage { get; set; }

        public List<CheckBoxModel> ColoursList { get; set; } = new List<CheckBoxModel>();


        public static implicit operator ProductEntity(AddProductViewModel product)
        {
            return new ProductEntity
            {
                ProductName = product.ProductName,
                Price = product.Price,
                ProductDescription = product.ProductDescription,
                ProductInStock = product.ProductInStock
            };
        }
    }
}
