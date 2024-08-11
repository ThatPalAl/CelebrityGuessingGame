using Microsoft.AspNetCore.Mvc;

namespace CelebrityGuessingGame.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}