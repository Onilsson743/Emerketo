using Ecommerceproject.Services;
using Ecommerceproject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerceproject.Controllers;

public class SignInController : Controller
{

    private readonly DataServices _data;

    public SignInController(DataServices data)
    {
        _data = data;
    }
    public IActionResult Index()
    {
        ViewData["Title"] = "Login";
        return View();
    }

    public IActionResult Registration()
    {
        ViewData["Title"] = "Register";
        return View();
    }

    [HttpPost]
    public IActionResult Registration(RegistrationViewModel model)
    {
        ViewData["Title"] = "Register";
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index");
        }
        return View(model);
    }
}
