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
            ViewBag.ErrorMessage = "No celebrities were found or the API failed to retrieve data.";
            return View(new List<Celebrity>());
        }
        return View(celebrities);
    }

    [HttpPost]
    public IActionResult ChooseCelebrity(string selectedCelebrity)
    {
        TempData["SelectedCelebrity"] = selectedCelebrity;
        TempData["RemainingCelebrities"] = TempData["RemainingCelebrities"] ?? _dbContext.Celebrities.ToList();
        return RedirectToAction("AskQuestion");
    }

    public IActionResult AskQuestion()
    {
        var remainingCelebrities = TempData["RemainingCelebrities"] as List<Celebrity>;
        if (remainingCelebrities == null || !remainingCelebrities.Any())
        {
            return RedirectToAction("Win");
        }
        var currentQuestion = "Is your celebrity male?";
        TempData["CurrentQuestion"] = currentQuestion;

        return View();
    }

    [HttpPost]
    public IActionResult AnswerQuestion(string answer)
    {
        var remainingCelebrities = TempData["RemainingCelebrities"] as List<Celebrity>;
        var currentQuestion = TempData["CurrentQuestion"] as string;
        
        if (currentQuestion == "Is your celebrity male?" && answer == "Yes")
        {
            remainingCelebrities = remainingCelebrities.Where(c => c.Gender == "male").ToList();
        }
        else if (currentQuestion == "Is your celebrity male?" && answer == "No")
        {
            remainingCelebrities = remainingCelebrities.Where(c => c.Gender == "female").ToList();
        }

        TempData["RemainingCelebrities"] = remainingCelebrities;

        return RedirectToAction("AskQuestion");
    }

    public IActionResult Win()
    {
        var selectedCelebrity = TempData["SelectedCelebrity"] as string;
        return Content($"I guessed it! Your celebrity is {selectedCelebrity}");
    }
}