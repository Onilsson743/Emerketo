using Ecommerceproject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerceproject.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Home";
        return View();
    }

    public IActionResult Contact()
    {
        ViewData["Title"] = "Contact";
        return View();
    }
    [HttpPost]
    public IActionResult Contact(ContactUsFormViewModel model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index");
        }
        ModelState.AddModelError("", "A user with the same email already exists");
        return View(model);
    }
}
