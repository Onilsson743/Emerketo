using System.ComponentModel.DataAnnotations;

namespace Ecommerceproject.Models.Entities;

public class OrderItemsEntity
{
    [Key]
    public int Id { get; set; }
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
    public int Quantity { get; set; }
    public int OrderId { get; set; }
    public OrderEntity Order { get; set; } = null!; 
    public int CartId { get; set; }
    public CartEntity Cart { get; set; } = null!;

}
