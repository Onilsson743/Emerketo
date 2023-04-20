using Ecommerceproject.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerceproject.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public string ProductDescription { get; set; } = null!;

    public string ProductCategory { get; set; } = null!;

    public int ProductInStock { get; set; }
    public string ProductImageUrl { get; set; } = null!;
    public List<string> Colours { get; set; } = new List<string>();
}
