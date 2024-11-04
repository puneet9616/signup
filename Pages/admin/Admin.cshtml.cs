using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace dotproject.Pages
{
   
        public class Admin : PageModel
    {
        private readonly ILogger<Admin> _logger;

        public Admin(ILogger<Admin> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public AdminUser AdminUser { get; set; } = new AdminUser();

        public void OnGet()
        {
            
        }

        public IActionResult OnPostSignup()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (AdminUser.Username == "admin" && AdminUser.Password == "123456")
            {
                return RedirectToPage("Dashboard"); 
            }

            ModelState.AddModelError(string.Empty, "Invalid username or password!");
            return Page();
        }
    }}