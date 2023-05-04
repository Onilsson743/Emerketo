using System.ComponentModel.DataAnnotations;

namespace Ecommerceproject.Models.Entities;


public class ProductCategoryEntity
{
    [Key]
    public int Id { get; set; }
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
    public int CategoryId { get; set; }
    public CategoriesEntity Categories { get; set; } = null!;
}
