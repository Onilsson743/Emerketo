using Ecommerceproject.Context;
using Ecommerceproject.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerceproject.Controllers;

public class AdminController : Controller
{
    private readonly DataServices _data;
   

    public AdminController(DataServices data)
    {
        _data = data;
    }

    public IActionResult Index()
    {

        return View();
    }
    public IActionResult AddProduct()
    {
        
        return View();
    }
    
}
