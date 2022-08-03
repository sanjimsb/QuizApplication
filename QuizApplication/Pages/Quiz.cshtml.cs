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
    public class QuizModel : PageModel
    {

        public readonly QuizContext _db;


        public IList<Quiz>? Quizes { get; set; }

        private readonly ILogger<QuizModel> _logger;

        public QuizModel(ILogger<QuizModel> logger, QuizContext db)
        {
            _logger = logger;
            _db = db;
        }

        [RequireHttps]
        public void OnGet([FromQuery] int Id)
        {
            Console.WriteLine(_db.Quiz!.Count());
            if (_db.Quiz!.Count() > 0)
            {
                ViewData["hasQuiz"] = true;
            }
            Console.WriteLine(Id);
            //db.Items.Where(x => x.userid == user_ID).Select(x => x.Id).Distinct();
            Quizes = _db.Quiz!.Where(q => q.ModuleId == Id).ToList();
        }
    }
}