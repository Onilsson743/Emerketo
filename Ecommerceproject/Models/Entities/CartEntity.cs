namespace Ecommerceproject.Models.Entities;

public class CartEntity
{
    public int Id { get; set; }
    public ICollection<OrderItemsEntity> OrderItems { get; set; } = null!;
    public ICollection<UserEntity> Users { get; set; } = null!;

}
