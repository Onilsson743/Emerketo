namespace Ecommerceproject.Models.Entities;

public class ProductColoursEntity
{
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;

    public int ColourId { get; set; }
    public ColourEntity Colour { get; set; } = null!;
}
