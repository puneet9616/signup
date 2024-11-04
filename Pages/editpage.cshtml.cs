using System;
using dotproject.Data;
using dotproject.Data.context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace dotproject.Pages
{
    public class editpage(applicationdb dbContext, ILogger<editpage> logger) : PageModel
    {
        private readonly ILogger<editpage> _logger = logger;
        private readonly applicationdb _context = dbContext;


        

        [BindProperty]
        public editclass edit {get;set;}

        public void OnGet(int id)
        {
            Console.WriteLine($"userId => {id}");
            var User = _context.Users.Find(id);

            if(User==null){
                _logger.LogError($"User with ID {id} not found.");
                // return RedirectToPage("Dashboard");
            }

            edit = new editclass
            {
                id = User.id,
                Username = User.Username,
                Email = User.Email,
                contact = User.contact,
                gender = User.gender
            };

            if (User == null)
            {
                _logger.LogError($"User with ID {id} not found.");
                
            }

            // return RedirectToPage("Dashboard");
        }

       public IActionResult OnPost(int id)
{
        if (!ModelState.IsValid)
        {
            return Page(); 
        }

  
    // Console.WriteLine($"Updating User: ID={User.id}, Username={User.Username}, Email={User.Email}, Contact={User.contact}, Gender={User.gender}");

    var userToUpdate = _context.Users.Find(id);
        if (userToUpdate != null)
        {
            
            userToUpdate.Username = edit.Username;
            userToUpdate.Email = edit.Email;
            userToUpdate.contact = edit.contact;
            userToUpdate.gender = edit.gender;

            _context.SaveChanges(); 
            return RedirectToPage("Dashboard"); 
        }

    ModelState.AddModelError("", "User not found."); 
    return Page(); 
}
}
}
