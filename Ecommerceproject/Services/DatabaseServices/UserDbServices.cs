using Ecommerceproject.Context;
using Ecommerceproject.Models;
using Ecommerceproject.Models.Entities;
using Ecommerceproject.Services.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Ecommerceproject.Services.DatabaseServices;

public class UserDbServices
{
    private readonly UserDbRepo _userRepo;
    private readonly UserManager<UserEntity> _userManager;

    public UserDbServices(UserDbRepo userRepo, UserManager<UserEntity> userManager)
    {
        _userRepo = userRepo;
        _userManager = userManager;
    }

    //Checks if there are any users in the database and returns a true or false value
    public async Task<bool> CheckAnyUserAsync()
    {
        var result = await _userRepo.GetAllAsync();
        if (result.Any())
        {
            return true;
        }
        return false;
    }

    public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
    {
        var userresult = await _userManager.Users.ToListAsync();
        if (userresult != null)
        {
            List<UserModel> users = new List<UserModel>();
            foreach (var user in userresult)
            {
                UserModel usermodel = new UserModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email!,
                    PhoneNumber = user.PhoneNumber!
                };

                var roleresult = await _userManager.GetRolesAsync(user);
                foreach (var role in roleresult)
                {
                    usermodel.Role = role;
                }
                users.Add(usermodel);
            }
            return users;
        } 
        return null!;
    }
}
