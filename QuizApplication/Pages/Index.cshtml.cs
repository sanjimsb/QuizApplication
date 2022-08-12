using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizDbContext;
using QuizModels;

namespace QuizApplication.Pages;

public class IndexModel : PageModel
{
    private readonly QuizContext _db;

    private readonly ILogger<IndexModel> _logger;

    public ICollection<Module>? Modules { get; set; }

    public IndexModel(ILogger<IndexModel> logger, QuizContext db)
    {
        _logger = logger;
        _db = db;
    }

    public void OnGet()
    {
        if (_db.Quiz!.Count() > 0)
        {
            ViewData["hasQuiz"] = true;
        }
        Modules = _db.Module!.Select(m => m).ToList();
    }
}

