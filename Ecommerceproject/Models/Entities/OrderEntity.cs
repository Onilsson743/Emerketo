namespace Ecommerceproject.Models.Entities;

public class OrderEntity
{
    public int Id { get; set; }
    public ICollection<OrderItemsEntity> OrderItems { get; set; }
    public int UserId { get; set; }
    public UserEntity User { get; set; } = null!;
    public int AdressId { get; set; }
    public AdressEntity Adress { get; set; } = null!;
    public DateTime DatePlaced { get; set; } = DateTime.Now;
    public int OrderStatusId { get; set; }
    public OrderStatusEntity OrderStatus { get; set; } = null!;


}
