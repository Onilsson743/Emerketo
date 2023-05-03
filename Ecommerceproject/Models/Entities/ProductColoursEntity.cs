using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ecommerceproject.Models.Entities;

[PrimaryKey(nameof(ProductId), nameof(ColourId))]
public class ProductColoursEntity
{
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;

    public int ColourId { get; set; }
    public ColourEntity Colour { get; set; } = null!;
}
