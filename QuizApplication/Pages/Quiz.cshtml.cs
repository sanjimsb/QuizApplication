using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly IHttpContextAccessor _httpContext;

        public int marks { get; set; }


        public IList<Quiz>? Quizes { get; set; }

        public IList<Module> ModuleDetail { get; set; }

        private readonly ILogger<QuizModel> _logger;

        public QuizModel(ILogger<QuizModel> logger, QuizContext db, IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _db = db;
            _httpContext = httpContext;
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
                    //4a2fbf15 - 0809 - 4d3c - aae3 - dd90841800eb
                        var getUserAns = new UserAnswer();
                        getUserAns.UserId = "4a2fbf15-0809-4d3c-aae3-dd90841800eb";
                        getUserAns.Answer = Request.Form[$"question-{item.Id}"].ToString();
                        getUserAns.QuizId = item.Id;
                        _db.Add<UserAnswer>(getUserAns);
                        _db.SaveChangesAsync();

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