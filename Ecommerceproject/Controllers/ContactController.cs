using Ecommerceproject.Services.DatabaseServices;
using Ecommerceproject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerceproject.Controllers
{
    public class ContactController : Controller
    {
        #region
        private readonly ContactFormDbServices _contactService;
        public ContactController(ContactFormDbServices dbServices)
        {
            _contactService = dbServices;
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactUsFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _contactService.AddContactFormAsync(model);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please fill in all the required fields");
            return View(model);
        }
    }
}
