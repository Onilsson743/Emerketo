using Ecommerceproject.Models;
using Ecommerceproject.Models.Entities;
using Ecommerceproject.Services;
using Ecommerceproject.Services.DatabaseServices;
using Ecommerceproject.Services.DatabaseServices.AuthenticationServices;
using Ecommerceproject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerceproject.Controllers.AuthenticationControllers;

public class SignInController : Controller
{
    #region
    private readonly AuthenticationDbService _authServices;
    private readonly UserDbServices _userServices;
    private readonly FileUploadServices _fileServices;

    public SignInController(AuthenticationDbService authServices, UserDbServices userServices, FileUploadServices fileServices)
    {
        _authServices = authServices;
        _userServices = userServices;
        _fileServices = fileServices;
    }
    #endregion

    #region SignIn
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

    #region Registration
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
                return View(model);
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
