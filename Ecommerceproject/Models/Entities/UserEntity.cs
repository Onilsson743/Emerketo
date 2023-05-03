using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerceproject.Models.Entities;

public class UserEntity : IdentityUser
{
    //[Key, ForeignKey(nameof(User))]
    //[Key]
    //public int AccountId { get; set; }
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = null!;
    public ICollection<UserAddressEntity> Address { get; set; } = new List<UserAddressEntity>();
    public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();

    //public IdentityUser User { get; set; } = null!;

}
