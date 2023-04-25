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

    [Required]
    public string ProductCategory { get; set; } = null!;

    [Required]
    public int ProductInStock { get; set; }
    public string ProductImageUrl { get; set; } = null!;
    public ICollection<ProductColoursEntity> Colours { get; set; } = new List<ProductColoursEntity>();
}
