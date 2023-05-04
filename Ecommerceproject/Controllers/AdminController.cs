using Ecommerceproject.Models;
using Ecommerceproject.Services.DatabaseServices;
using Ecommerceproject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Ecommerceproject.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    #region
    private readonly ProductDbServices _productService;
    private readonly ColourDbServices _colourService;
    private readonly CategoryDbServices _categoryService;

    public AdminController(ProductDbServices productService, ColourDbServices colourService, CategoryDbServices categoryService)
    {
        _productService = productService;
        _colourService = colourService;
        _categoryService = categoryService;
    }
    #endregion
    public async Task<IActionResult> Index()
    {
        IEnumerable<ProductModel> model = await _productService.GetAllAsync();
        return View(model);
    }
    public async Task<IActionResult> AddProduct()
    {
        var model = new AddProductViewModel()
        {
            ColoursList = await _colourService.GetAllColours(),
            ProductCategory = await _categoryService.GetAllCategories()
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(AddProductViewModel model)
    {
        if (ModelState.IsValid)
        {
            await _productService.AddAsync(model);
            return RedirectToAction("Index");
        }

        return View(model);
    }
}
