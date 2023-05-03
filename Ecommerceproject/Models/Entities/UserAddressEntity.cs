using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ecommerceproject.Models.Entities;


public class UserAddressEntity
{
    [Key]
    public int Id { get; set; }
    public string UserId { get; set; }
    public UserEntity User { get; set; } = null!;
    public int AddressId { get; set; }
    public AddressEntity Address { get; set; } = null!;
}
