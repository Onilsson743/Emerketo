using Ecommerceproject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerceproject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactUsFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "A user with the same email already exists");
            return View(model);
        }
    }
}
