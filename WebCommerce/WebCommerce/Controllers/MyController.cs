using Microsoft.AspNetCore.Mvc;

namespace WebCommerce.Controllers;

public class MyController : Controller
{
    public IActionResult Index()
    {
        // Your logic here
        return View();
    }
}