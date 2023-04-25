using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerceproject.Models.Entities;

public class UserEntity 
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column(TypeName = "char(13)")]
    public string PhoneNumber { get; set; } = null!;

    public int? AdressId { get; set; }
    public AdressEntity Adress { get; set; } = null!;
    public ICollection<OrderEntity> Orders { get; set; } = null!;

    public IdentityUser User { get; set; } = null!;
}
