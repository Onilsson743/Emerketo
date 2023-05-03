using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ecommerceproject.Models.Entities;


[PrimaryKey(nameof(ProductId), nameof(CategoryId))]
public class ProductCategoryEntity
{
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
    public int CategoryId { get; set; }
    public CategoriesEntity Categories { get; set; } = null!;
}
