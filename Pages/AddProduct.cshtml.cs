using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace dotproject.Pages
{
    public class AddProduct : PageModel
    {
        private readonly ILogger<AddProduct> _logger;

        public AddProduct(ILogger<AddProduct> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}