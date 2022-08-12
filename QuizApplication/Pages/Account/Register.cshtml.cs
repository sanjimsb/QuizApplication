using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizModels;

namespace QuizApplication.Pages.Account
{
    public class RegisterModel : PageModel
    {
        public User user;
        public void OnGet()
        {
        }
    }
}
