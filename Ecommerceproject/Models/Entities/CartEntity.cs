namespace Ecommerceproject.Models.Entities;

public class CartEntity
{
    public int Id { get; set; }
    public List<OrderItemsEntity> OrderItems { get; set; } = new List<OrderItemsEntity>();

}
