using System.ComponentModel.DataAnnotations;

namespace Ecommerceproject.Models.Entities;

public class OrderStatusEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string Status { get; set; } = string.Empty;

    public List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}
