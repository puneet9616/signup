
using System.Collections.Generic;

namespace MyRazorApp.Models
{
    public class Userform
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public int contact{get; set;}
        public string gender{get; set;}


        public IFormFile Profileimage{get;set;}
        

        // public List<string> Roles { get; set; } = new List<string>();
    }
}
