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
    public class AddModuleModel : PageModel
    {
        private readonly QuizContext _db;

        [FromForm]
        public Module? Modules { get; set; }

        public AddModuleModel(QuizContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            var getUserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (getUserId == null)
            {
                Response.Redirect("/Identity/Account/Login");
            }
            if (_db.Module!.Count() > 0)
            {
                ViewData["hasModule"] = true;
            }
        }

        public void OnPost()
        {
            
                _db.Add(Modules!);
                _db.SaveChangesAsync();
            
        }
    }
}

