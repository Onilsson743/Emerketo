using Ecommerceproject.Context;
using Ecommerceproject.Models;
using Ecommerceproject.Models.Entities;
using Ecommerceproject.Services.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

    //Gets all the users
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

    //Gets one user
    #region
    public async Task<UserModel> GetOneUserAsync(string id)
    {
        var result = await _userRepo.GetAsync(x => x.Id == id);
        if (result != null)
        {
            var roleresult = await _userManager.GetRolesAsync(result);
            if (roleresult != null)
            {
                UserModel user = result;
                try
                {
                    user.Role = roleresult[0]!;
                }catch { }                
                return user;
            }            
        }
        return null!;
    }
    public async Task<UserModel> GetOneUserAsync(UserModel model)
    {
        var result = await _userRepo.GetAsync(x => x.Email == model.Email);
        if (result != null)
        {
            var roleresult = await _userManager.GetRolesAsync(result);
            if (roleresult != null)
            {
                UserModel user = result;
                try
                {
                    user.Role = roleresult[0]!;
                }
                catch { }
                return user;
            }
        }
        return null!;
    }
    #endregion

    //update a users role
    public async Task<UserModel> UpdateUserRoleAsync(string id, string updatedrole)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user != null)
        {
            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);

            await _userManager.AddToRoleAsync(user, updatedrole);

            await _userManager.UpdateAsync(user);
            return user;
        }
        return null!;       
    }


}
