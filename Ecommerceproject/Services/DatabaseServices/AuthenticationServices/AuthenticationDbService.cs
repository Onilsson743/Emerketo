using Ecommerceproject.Models.Entities;
using Ecommerceproject.Services.Repositories;
using Ecommerceproject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static System.Net.Mime.MediaTypeNames;

namespace Ecommerceproject.Services.DatabaseServices.AuthenticationServices;

public class AuthenticationDbService
{
    #region
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInService;
    private readonly AddressDbServices _addressService;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserDbServices _userService;
    private readonly FileUploadServices _fileService;


    public AuthenticationDbService(UserManager<UserEntity> authService, AddressDbServices addressService, SignInManager<UserEntity> signInService, RoleManager<IdentityRole> roleManager, UserDbServices userService, FileUploadServices fileService)
    {
        _userManager = authService;
        _addressService = addressService;
        _signInService = signInService;
        _roleManager = roleManager;
        _userService = userService;
        _fileService = fileService;
    }

    #endregion

    //Check if user already exists
    public async Task<bool> UserExistsAsync(Expression<Func<UserEntity, bool>> expression)
    {
        return await _userManager.Users.AnyAsync(expression);
    }


    //Register a new user
    public async Task<bool> RegisterAsync(RegistrationViewModel model)
    {
        UserEntity user = model;
        if (model.ImageFile != null)
        {
            user.ImageUrl = $"{user.Email}_{model.ImageFile.FileName}";
            await _fileService.SaveProfileImageAsync(user, model.ImageFile);
        }

        var anyornull = await _userService.CheckAnyUserAsync();
        
        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            if (anyornull == false)
            {
                var defaultrole = await _roleManager.FindByNameAsync("Admin");
                if (defaultrole != null)
                {
                    IdentityResult roleresult = await _userManager.AddToRoleAsync(user, defaultrole.Name!);
                }
            }
            else
            {
                var defaultrole = await _roleManager.FindByNameAsync("Member");
                if (defaultrole != null)
                {
                    IdentityResult roleresult = await _userManager.AddToRoleAsync(user, defaultrole.Name!);
                }
            }

            var address = await _addressService.GetOrCreateAsync(model);
            if (address != null)
            {
                await _addressService.AddAddressAsync(user, address);
                return true;
            }
        }
        return false;
    }

    //Login user
    public async Task<bool> LoginAsync(SigninViewModel model)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
        if (user != null) 
        {
            var result = await _signInService.PasswordSignInAsync(user, model.Password, model.KeepMeSignedIn, false);
            return result.Succeeded;
        }
        return false;
    }
}
