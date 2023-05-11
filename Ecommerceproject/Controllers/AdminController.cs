using Ecommerceproject.Models;
using Ecommerceproject.Models.Entities;
using Ecommerceproject.Services.DatabaseServices;
using Ecommerceproject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Linq;

namespace Ecommerceproject.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    
    #region constructors
    private readonly ProductDbServices _productService;
    private readonly ColourDbServices _colourService;
    private readonly CategoryDbServices _categoryService;
    private readonly UserDbServices _userService;

    public AdminController(ProductDbServices productService, ColourDbServices colourService, CategoryDbServices categoryService, UserDbServices userService)
    {
        _productService = productService;
        _colourService = colourService;
        _categoryService = categoryService;
        _userService = userService;
    }
    #endregion
    public async Task<IActionResult> Index()
    {
        IEnumerable<ProductModel> model = await _productService.GetAllAsync();
        return View(model);
    }

    #region Add new product page
    //Add product page
    public async Task<IActionResult> AddProduct()
    {
        var model = new AddProductViewModel()
        {
            ColoursList = await _colourService.GetAllColours(),
            ProductCategory = await _categoryService.GetAllCategories()
        };
        return View(model);
    }

    //Add product to database
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
    #endregion

    //Page with a list of all the users
    public async Task<IActionResult> Users()
    {
        var users = await _userService.GetAllUsersAsync();

        return View(users);
    }


    #region Edit selected user page
    public async Task<IActionResult> EditUser(string id)
    {
        var user = await _userService.GetOneUserAsync(id);
        if (user != null)
        {
            return View(user);
        }
        return RedirectToAction("Users");
        
    }

    [HttpPost]
    public async Task<IActionResult> EditUser(string id,string role)
    {
        var updated = await _userService.UpdateUserRoleAsync(id, role);
        if (updated != null)
        {
            return RedirectToAction("Users");
        }
        return View();
    }
    #endregion

    public async Task<IActionResult> ProductsPage()
    {
        IEnumerable<ProductModel> model = await _productService.GetAllAsync();
        return View(model);
    }

}
