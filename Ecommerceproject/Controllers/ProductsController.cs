using Ecommerceproject.Services.DatabaseServices;
using Microsoft.AspNetCore.Mvc;

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
            var result = await _productService.GetOneAsync(articlenumber);

            if (result != null) 
            {
                return View(result);
            }


            return RedirectToAction("Index");
        }
    }
}
