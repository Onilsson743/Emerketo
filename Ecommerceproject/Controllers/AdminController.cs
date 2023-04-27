using Ecommerceproject.Models;
using Ecommerceproject.Services.DatabaseServices;
using Ecommerceproject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Ecommerceproject.Controllers;

public class AdminController : Controller
{
    private readonly ProductDbServices _productService;
    private readonly ColourDbServices _colourService;

    public AdminController(ProductDbServices productService, ColourDbServices colourService)
    {
        _productService = productService;
        _colourService = colourService;
    }

    public IActionResult Index()
    {
        return View();
    }
    public async Task<IActionResult> AddProduct()
    {
        var model = new AddProductViewModel()
        {
            ColoursList = await _colourService.GetAllColours()          
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(AddProductViewModel model)
    {
        if (ModelState.IsValid)
        {
            await _productService.AddAsync(model);
        }

        return View(model);
    }
}
