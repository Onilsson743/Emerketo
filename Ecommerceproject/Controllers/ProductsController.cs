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


        //Redirects to the details page of the selected product
        [HttpGet]
        public async Task<IActionResult> Details(Guid articlenumber) 
        {

            //var id = Request.Path.Value.Split("/");
            var result = await _productService.GetOneAsync(articlenumber);

            if (result != null) 
            {
                return View(result);
            }


            return RedirectToAction("Index");
        }
    }
}
