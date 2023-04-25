using Microsoft.AspNetCore.Mvc;

namespace Ecommerceproject.ViewModels
{
    public class LoginFormViewModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
