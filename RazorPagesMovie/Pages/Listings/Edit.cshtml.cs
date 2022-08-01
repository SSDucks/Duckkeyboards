﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Listings
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EditModel(RazorPagesMovie.Data.RazorPagesMovieContext context,
            IWebHostEnvironment web)
        {
            _context = context;
            webHostEnvironment = web;
        }

        [BindProperty]
        public Listing Listing { get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Listing = await _context.Listings.FirstOrDefaultAsync(m => m.listingID == id);

            if (Listing == null)
            {
                return NotFound();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            _context.Attach(Listing).State = EntityState.Modified;

            try
            {
                if (Photo != null)
                {
                    // If there is an existing photo, it needs to be deleted
                    // before uploading the new one, so check if there is
                    // an existing photo
                    if (Listing.content != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath,
                            "images", Listing.content);
                        System.Diagnostics.Debug.WriteLine(filePath);
                        System.IO.File.Delete(filePath);
                    }
                    
                    System.Diagnostics.Debug.WriteLine("BBBB" + ProcessUploadedFile());
                    Listing.content = ProcessUploadedFile();
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListingExists(Listing.listingID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            _context.Listings.Update(Listing);
            return RedirectToPage("./Index");
        }

        private bool ListingExists(int id)
        {
            return _context.Listings.Any(e => e.listingID == id);
        }
        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                if (string.IsNullOrWhiteSpace(webHostEnvironment.WebRootPath))
                {
                    webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}