using Ecommerceproject.Services;
using Ecommerceproject.Services.DatabaseServices.AuthenticationServices;
using Ecommerceproject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerceproject.Controllers;

public class SignInController : Controller
{
    #region
    private readonly AuthenticationDbService _authServices;

    public SignInController(AuthenticationDbService authServices)
    {
        _authServices = authServices;
    }
    #endregion

    //SignIn
    #region
    public IActionResult Index()
    {
        
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(SigninViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (await _authServices.LoginAsync(model))
                return RedirectToAction("Index", "Home");
        }
        ModelState.AddModelError("", "Incorrect email or password");
        return View(model);
    }
    #endregion

    //Registration
    #region
    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Registration(RegistrationViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (await _authServices.UserExistsAsync(x => x.Email == model.Email))
            {
                ModelState.AddModelError("", "A user with the same email already exists");
            }
            if (await _authServices.RegisterAsync(model))
            {
                return RedirectToAction("Index");
            }                
        }
        return View(model);
    }
    #endregion

}
