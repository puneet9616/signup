using System.Linq; // Make sure to include this for LINQ
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using dotproject.Data; // Ensure you have the correct namespace for your User class
using dotproject.Data.context;

namespace dotproject.Pages
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginPageModel : PageModel
    {
        private readonly ILogger<LoginPageModel> _logger;
        private readonly applicationdb _context;

        public LoginPageModel(ILogger<LoginPageModel> logger, applicationdb context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public Login Ob { get; set; } = new Login();

        public IActionResult OnPost()
        {
            
            var user = _context.Users.FirstOrDefault(u => u.Username == Ob.Username && u.Password == Ob.Password); 

            if (user != null)
            {
                TempData["Message"] = "Login successful! Welcome!";
                TempData["name"] = Ob.Username;
                TempData["Page"] = "/Index";
                TempData["Click"] = "Go to Signup Page";
                return RedirectToPage("/resonse");
            }

            TempData["ErrorMessage"] = "Invalid username or password.";
            return Page();
        }
    }
}
