using Ecommerceproject.Models.ViewModels;
using Ecommerceproject.Services.DatabaseServices;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Ecommerceproject.Controllers;

public class AdminController : Controller
{
    private readonly ProductDbServices _productService;

    public AdminController(ProductDbServices productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult AddProduct()
    {
        
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(AddProductViewModel model)
    {
        
        await _productService.AddAsync(model);
        return View();
    }
}
