using Ecommerceproject.Models.Entities;
using Ecommerceproject.ViewModels;

namespace Ecommerceproject.Models;

public class UserModel
{
    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Role { get; set; } = null!;


    public static implicit operator UserEntity(UserModel model)
    {
        return new UserEntity
        {
            Id = model.Id,
            UserName = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber
        };
    }

}
