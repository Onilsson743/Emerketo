using Ecommerceproject.Models;
using Ecommerceproject.Services.DatabaseServices;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Ecommerceproject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductDbServices _productService;

        public ProductsController(ProductDbServices productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Products";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details() 
        {

            var id = Request.Path.Value.Split("/");
            var result = await _productService.GetOneAsync(Int32.Parse(id[3]));

            if (result != null) 
            {
                return View(result);
            }


            return RedirectToAction("Index");
        }
    }
}
