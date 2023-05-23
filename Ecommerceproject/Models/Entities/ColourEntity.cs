using System.ComponentModel.DataAnnotations;

namespace Ecommerceproject.Models.Entities;

public class ColourEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    [StringLength(20)]
    public string Colour { get; set; } = string.Empty;
    public List<ProductColoursEntity> Products { get; set; } = new List<ProductColoursEntity>();
}
