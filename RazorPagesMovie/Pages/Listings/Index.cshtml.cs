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
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RazorPagesMovie.Pages.Listings
{
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
        //public string i { get; set; }

        public IList<Listing> Listing { get;set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Entered Text contain Invalid characters")]
        public string newSearch { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Entered Text contain Invalid characters")]
        public string searchStringType { get; set; }

        public async Task OnGetAsync(string newSearch, string searchStringType)
        {
            var listingtype = from t in _context.Listings
                         select t;

            if (!String.IsNullOrEmpty(searchStringType))
            {
                listingtype = listingtype.Where(s => s.itemType.Contains(searchStringType));
            }

            Listing = await listingtype.ToListAsync();

            var litty = from owo in _context.Listings
                              select owo;


            if (!String.IsNullOrEmpty(newSearch) && Regex.IsMatch(newSearch, @"^[a-zA-Z0-9]+$"))
            {
                listingtype = listingtype.Where(s => s.itemName.Contains(newSearch));
            }
            else
            {
                if (!String.IsNullOrEmpty(newSearch))
                {
                    TempData["message"] = "Invalid input";
                }
            }

            Listing = await listingtype.ToListAsync();

        }


    }
}
