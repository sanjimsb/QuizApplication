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

        public int marks { get; set; }


        public IList<Quiz>? Quizes { get; set; }

        public IList<Module> ModuleDetail { get; set; }

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
            ModuleDetail = _db.Module!.Where(m => m.Id == Id).ToList();
        }

        public void OnPost([FromQuery] int Id)
        {
                Quizes = _db.Quiz!.Where(q => q.ModuleId == Id).ToList();
                if (Quizes != null)
                {
                    foreach (Quiz item in Quizes)
                    {
                        if (Request.Form[$"question-{item.Id}"].ToString() == item.CorrectAnswer!.ToString())
                        {
                            marks += 1;
                        }
                    }
                }
                Console.WriteLine(marks);
        }
    }
}