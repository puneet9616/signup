using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace dotproject.Pages
{
    public class resonse : PageModel
    {
        private readonly ILogger<resonse> _logger;

        public resonse(ILogger<resonse> logger)
        {
            _logger = logger;
        }
    


public IActionResult OnPostGoToResponse()
    {
        TempData["Message"] = "You have successfully navigated to the response page!";
        return RedirectToPage("/loginpage");
    }

        public void OnGet()
        {
        }
    }
}