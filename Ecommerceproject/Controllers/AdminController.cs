﻿using Ecommerceproject.Models;
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
    //Dependency injection
    #region
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

    //Add new product section
    #region
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

    public async Task<IActionResult> Users()
    {
        var test = await _userService.GetAllUsersAsync();

        return View(test);
    }

}
