using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dotproject.Data.context; // Use the correct namespace for your applicationdb context and User model
using dotproject.Data;
using Microsoft.EntityFrameworkCore;

namespace dotproject.Pages
{
    public class Dashboard : PageModel
    {
        private readonly applicationdb _context;

        public Dashboard(applicationdb dbContext)
        {
            _context = dbContext;
        }

        public List<User> UserData { get; set; }  

        public void OnGet()
        {
            UserData = _context.Users.ToList(); 
        }




        public async Task<IActionResult> OnPostToggleUserStatus(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.id == userId);
            if (user != null)
            {
               
                user.Isactive = user.Isactive == 1 ? 0 : 1; 
                await _context.SaveChangesAsync();
            }
            return RedirectToPage(); 
        }


         public IActionResult OnPostDeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}
