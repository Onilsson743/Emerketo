using Ecommerceproject.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerceproject.Models;

public class ProductModel
{
    public Guid Id { get; set; } 
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
    public string ProductDescription { get; set; } = null!;
    public List<string> ProductCategory { get; set; } = null!;
    public int ProductInStock { get; set; }
    public List<string>? ProductImageUrl { get; set; }
    public List<string> Colours { get; set; } = new List<string>();
}
