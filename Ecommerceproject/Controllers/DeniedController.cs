using Microsoft.AspNetCore.Mvc;

namespace Ecommerceproject.Controllers
{
    public class DeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
