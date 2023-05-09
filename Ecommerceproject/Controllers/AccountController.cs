using Ecommerceproject.Models;
using Ecommerceproject.Models.Entities;
using Ecommerceproject.Services.DatabaseServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerceproject.Controllers;


[Authorize]
public class AccountController : Controller
{
    private readonly UserDbServices _userService;

    public AccountController(UserDbServices userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            UserModel user = new UserModel
            {
                Email = User.Identity!.Name!
            };
            UserModel result = await _userService.GetOneUserAsync(user);
            return View(result);
        }
        catch { }

        return LocalRedirect("/");
    }
}
