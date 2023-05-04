using Ecommerceproject.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerceproject.Controllers.AuthenticationControllers;

public class SignOutController : Controller
{
    private readonly SignInManager<UserEntity> _signInManager;

    public SignOutController(SignInManager<UserEntity> signInManager)
    {
        _signInManager = signInManager;
    }

    //SignOut
    #region
    public async Task<IActionResult> Index()
    {
        if (_signInManager.IsSignedIn(User))
        {
           await _signInManager.SignOutAsync();
        }

        return LocalRedirect("/");
    }
    #endregion
}
