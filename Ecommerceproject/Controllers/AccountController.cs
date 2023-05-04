using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerceproject.Controllers;


[Authorize]
public class AccountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
