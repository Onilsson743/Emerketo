using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerceproject.Models.Entities;

public class UserEntity : IdentityUser
{
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;
    public ICollection<UserAddressEntity> Address { get; set; } = new List<UserAddressEntity>();
    public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();

    public static implicit operator UserModel(UserEntity model)
    {
        return new UserModel
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email!,
            PhoneNumber = model.PhoneNumber!
        };
    }
}
