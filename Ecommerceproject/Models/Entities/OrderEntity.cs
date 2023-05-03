using System.ComponentModel.DataAnnotations;

namespace Ecommerceproject.Models.Entities;

public class OrderEntity
{
    [Key]
    public int Id { get; set; }
    public ICollection<OrderItemsEntity> OrderItems { get; set; } = new List<OrderItemsEntity>();
    public string UserId { get; set; }
    public UserEntity User { get; set; } = null!;
    public int AdressId { get; set; }
    public AddressEntity Adress { get; set; } = null!;
    public DateTime DatePlaced { get; set; } = DateTime.Now;
    public int OrderStatusId { get; set; }
    public OrderStatusEntity OrderStatus { get; set; } = null!;


}
