using CelebrityGuessingGame.Models;
using CelebrityGuessingGame.Services;
using Microsoft.AspNetCore.Mvc;

namespace CelebrityGuessingGame.Controllers;

public class GameController : Controller
{
    private readonly ApiService _apiService;
    private readonly DatabaseService _dbContext;

    public GameController(ApiService apiService, DatabaseService dbContext)
    {
        _apiService = apiService;
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index()
    {
        var celebrities = await _apiService.GetCelebritiesAsync("ik8nOg4Czi2xqjRUZiDYAg==G1aVlZ7TRMJnRVrY");
        if (celebrities == null || !celebrities.Any())
        {
            ViewData["ErrorMessage"] = "No celebrities were found.";
            return View("Error");
        }
        return View(celebrities);
    }


    [HttpPost]
    public IActionResult SaveScore(string name, int score)
    {
        var user = new User { Name = name, Score = score };
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
}