using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Listings
{
    [Authorize(Roles = "Shopkeeper")]
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;


        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context
            , IWebHostEnvironment web)
        {
            _context = context;
            this.webHostEnvironment = web;
        }

        public IList<Listing> Listing { get;set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        public async Task OnGetAsync()
        {
            Listing = await _context.Listings.ToListAsync();
        }


    }
}
