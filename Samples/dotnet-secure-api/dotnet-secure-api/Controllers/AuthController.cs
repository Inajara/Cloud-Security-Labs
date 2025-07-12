using Microsoft.AspNetCore.Mvc;

namespace dotnet_secure_api.Controllers;

public class AuthController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}