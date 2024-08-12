using CelebrityGuessingGame.Models;
using CelebrityGuessingGame.Services;
using Microsoft.AspNetCore.Mvc;

namespace CelebrityGuessingGame.Controllers
{
    public class GameController : Controller
    {
        private readonly ApiService _apiService;

        public GameController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FetchCelebrity(string name)
        {
            
            try
            {
                Console.WriteLine("FetchCelebrity called with name: " + name);
                
                if (string.IsNullOrEmpty(name))
                {
                    TempData["ErrorMessage"] = "You must enter a celebrity's name.";
                    return RedirectToAction("Index");
                }

                var apiKey = "?";
                var celebrity = await _apiService.GetCelebrityByNameAsync(apiKey, name);

                if (celebrity != null)
                {
                    Console.WriteLine("Celebrity found: " + celebrity.Name);
                    return View("DisplayCelebrity", celebrity);
                }
                else
                {
                    Console.WriteLine("Celebrity not found.");
                    ViewBag.ErrorMessage = "Celebrity not found.";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                TempData["ErrorMessage"] = "An error occurred while fetching the celebrity.";
                return RedirectToAction("Index");
            }
            
        }

    }
}