using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controller;

public class AuthController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}