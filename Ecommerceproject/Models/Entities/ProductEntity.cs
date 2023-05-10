using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerceproject.Models.Entities;

public class ProductEntity
{
    [Key]
    public Guid ArticleNumber { get; set; } = Guid.NewGuid();

    [StringLength(100)]
    public string ProductName { get; set; } = null!;

    [Required]
    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    public string ProductDescription { get; set; } = null!;

    public ICollection<ProductCategoryEntity> Categories { get; set; } = new List<ProductCategoryEntity>();

    [Required]
    public int ProductInStock { get; set; }

    public string? ProductImageUrl { get; set; }
    public ICollection<ProductColoursEntity> Colours { get; set; } = new List<ProductColoursEntity>();
}
