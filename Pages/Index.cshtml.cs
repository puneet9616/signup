using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using dotproject.Data;
using dotproject.Data.context;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using MyRazorApp.Models;

namespace MyRazorApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Userform NewUser { get; set; } = new Userform();

        public List<SelectListItem> Options { get; set; } = new List<SelectListItem>();
        public object FileName { get; private set; }

        private readonly applicationdb _context;

        private readonly IWebHostEnvironment _environment;

        public IndexModel(applicationdb dbContext, IWebHostEnvironment environment)
        {
            _context = dbContext;
            _environment = environment;
        }

        public void OnGet()
        {
            Options.Add(new SelectListItem { Value = "1", Text = "Shyam" });
            Options.Add(new SelectListItem { Value = "2", Text = "Shyam1" });
            Options.Add(new SelectListItem { Value = "3", Text = "Shyam2" });
        }

        public async Task<IActionResult> OnPostSignupAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool existingEmail = _context.Users.Any(u => u.Email == NewUser.Email);
            if (existingEmail)
            {
                ModelState.AddModelError("NewUser.Email", "This email is already taken.");
                return Page();
            }

            var existingContact = _context.Users.Any(u => u.contact == NewUser.contact);
            if (existingContact)
            {
                ModelState.AddModelError("NewUser.contact", "This contact number is already taken.");
                return Page();
            }

            string fileName = string.Empty;

            if (NewUser.Profileimage != null && NewUser.Profileimage.Length > 0)
            {

                fileName = Path.GetFileName(NewUser.Profileimage.FileName);


                var filePath = Path.Combine(_environment.WebRootPath, "profileimage", fileName);


                Directory.CreateDirectory(Path.Combine(_environment.WebRootPath, "profileimage"));


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await NewUser.Profileimage.CopyToAsync(stream);
                }


                // doNewUser.Profileimage = $"/profileimage/{fileName}";
            }

            var newUser = new dotproject.Data.User
            {
                Username = NewUser.Username,
                Email = NewUser.Email,
                ConfirmPassword = NewUser.ConfirmPassword,
                Password = NewUser.Password,
                contact = NewUser.contact,
                gender = NewUser.gender,
                Profileimage = fileName,
            };


            TempData["name"] = NewUser.Username;
            TempData["Page"] = "/resonse";

            TempData["Click"] = "Go to Login Page";

            _context.Users.Add(newUser);
            _context.SaveChanges();

            TempData["Message"] = "Successfully stored";
            return RedirectToPage("/resonse");
        }
    }
}
