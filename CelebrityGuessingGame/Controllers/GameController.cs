using CelebrityGuessingGame.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CelebrityGuessingGame.Controllers
{
    public class GameController : Controller
    {
        private static List<QuestionModel> Questions = new List<QuestionModel>
        {
            new QuestionModel 
            { 
                QuestionText = "Is the celebrity male?", 
                Options = new List<Option> 
                { 
                    new Option { OptionText = "Yes" }, 
                    new Option { OptionText = "No" } 
                } 
            },
            new QuestionModel 
            { 
                QuestionText = "Is the person tall, medium, or short?", 
                Options = new List<Option> 
                { 
                    new Option { OptionText = "Tall" }, 
                    new Option { OptionText = "Medium" }, 
                    new Option { OptionText = "Short" } 
                } 
            },
            // Add more questions as needed...
        };

        public IActionResult Index()
        {
            var viewModel = new GameViewModel
            {
                Questions = Questions,
                Answers = new List<string>()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SubmitAnswers(GameViewModel model)
        {
            // Process the answers (e.g., store them, analyze them, etc.)
            // For now, we'll just redirect to the result page with a dummy result.

            return RedirectToAction("Result", new { result = "Tom Cruise" });
        }

        public IActionResult Result(string result)
        {
            ViewBag.FoundCelebrity = result;
            return View();
        }
    }
}