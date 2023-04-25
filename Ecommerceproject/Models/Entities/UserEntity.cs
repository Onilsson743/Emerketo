using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerceproject.Models.Entities;

public class UserEntity
{
    [Key, ForeignKey(nameof(User))]
    public string PersonId { get; set; } = null!;
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = null!;
    public int? AdressId { get; set; }
    public AdressEntity Adress { get; set; } = null!;
    public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();

    public IdentityUser User { get; set; } = null!;

}
