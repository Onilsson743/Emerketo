using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerceproject.Models.Entities;

public class ProductEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string ProductName { get; set; } = null!;

    [Required]
    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    [Required]
    public string ProductDescription { get; set; } = null!;

    public List<ProductCategoryEntity> Categories { get; set; } = new List<ProductCategoryEntity>();

    [Required]
    public int ProductInStock { get; set; }
    public string ProductImageUrl { get; set; } = null!;
    public List<ProductColoursEntity> Colours { get; set; } = new List<ProductColoursEntity>();
}
