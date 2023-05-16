using Ecommerceproject.Services.DatabaseServices;
using Ecommerceproject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerceproject.Controllers;

public class HomeController : Controller
{

    private readonly ProductDbServices _productService;
    public HomeController(ProductDbServices productService)
    {
        _productService = productService;
    }
    public async Task<IActionResult> Index()
    {
        ViewData["Title"] = "Home";
        var products = await _productService.GetAllAsync();
        return View(products);
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
