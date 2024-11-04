using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotproject.Data.context;
using dotproject.Data.entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace dotproject.Pages
{
    public class ProductPage : PageModel
    {
        private readonly applicationdb _context;

    public List<productEntity> Products { get; set; } = new List<productEntity>();

    public ProductPage(applicationdb context)
    {
        _context = context;
    }

    public void OnGet()
    {
        // Fetch the products from the database
        Products = _context.products.ToList(); // Retrieves all products
    }

    // Other methods for adding products, etc.
}

    public class Product
    {
    }

    internal class ProductPageModel
    {
    }

    internal class ApplicationDbContext
    {
        public object Products { get; internal set; }
    }
}