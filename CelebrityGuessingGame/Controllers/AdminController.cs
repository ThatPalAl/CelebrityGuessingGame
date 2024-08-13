using CelebrityGuessingGame.Models;
using CelebrityGuessingGame.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CelebrityGuessingGame.Controllers
{
    public class AdminController : Controller
    {
        private readonly DatabaseService _dbContext;

        public AdminController(DatabaseService dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var questions = await _dbContext.Questions.Include(q => q.Options).ToListAsync();
            return View(questions);
        }

        public IActionResult CreateQuestion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(Question question)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Questions.Add(question);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(question);
        }

        public async Task<IActionResult> EditQuestion(int id)
        {
            var question = await _dbContext.Questions.Include(q => q.Options).FirstOrDefaultAsync(q => q.Id == id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        [HttpPost]
        public async Task<IActionResult> EditQuestion(Question question)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Questions.Update(question);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(question);
        }

        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _dbContext.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            _dbContext.Questions.Remove(question);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
