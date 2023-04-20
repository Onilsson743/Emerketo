using Microsoft.AspNetCore.Mvc;

namespace Ecommerceproject.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Products";
            return View();
        }
    }
}
