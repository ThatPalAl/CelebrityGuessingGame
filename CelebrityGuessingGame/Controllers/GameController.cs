using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


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
        var celebrities = await _apiService.GetCelebritiesAsync("YOUR_API_KEY_HERE");
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