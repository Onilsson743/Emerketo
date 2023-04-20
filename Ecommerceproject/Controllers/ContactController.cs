using Microsoft.AspNetCore.Mvc;

namespace Ecommerceproject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
