using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizDbContext;
using QuizModels;

namespace QuizApplication.Pages
{
    public class AddQuizModel : PageModel
    {
        public readonly QuizContext _db;

        [FromForm]
        public Quiz? Quizes { get; set; }

        public ICollection<Module>? Modules { get; set; }

        public AddQuizModel(QuizContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            if ((_db.Module!).Any())
            {
                ViewData["hasModule"] = true;
            }

            Modules = _db.Module!.Select(m => m).ToList();
        }

        public void OnPost()
        {
                Modules = _db.Module!.Select(m => m).ToList();
                _db.Add<Quiz>(Quizes!);
                _db.SaveChangesAsync();
        }
    }
}