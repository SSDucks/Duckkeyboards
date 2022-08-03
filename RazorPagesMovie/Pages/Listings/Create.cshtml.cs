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
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Listings
{
    [Authorize(Roles = "Shopkeeper")]
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;
        private readonly IWebHostEnvironment _hostenvironment;

        public CreateModel(RazorPagesMovie.Data.RazorPagesMovieContext context
            , IWebHostEnvironment webHostEnvironment)
        {
            this._hostenvironment = webHostEnvironment; 
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Listing Listing { get; set; }
        [BindProperty]
        public FileViewModel FileUpload { get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Photo != null)
            {
                if (IsImage(Photo))
                {
                    Listing.content = ProcessUploadedFile();
                    _context.Listings.Add(Listing);
                }
                else
                {
                    TempData["message"] = "Please upload a valid file type";
                    return RedirectToPage("Create");
                }
            }

            //await _context.SaveChangesAsync();

            // Once a record is addedm create an audit record
            if(await _context.SaveChangesAsync() > 0)
            {
                // create an auditrecord object
                var auditrecord = new AuditRecord();
                auditrecord.AuditActionType = "Create listing object";
                auditrecord.DateTimeStamp = DateTime.Now;
                auditrecord.KeyMovieFieldID = Listing.listingID;
                // Get current Logged in user
                var userID = User.Identity.Name.ToString();
                auditrecord.Username = userID;
                _context.AuditRecords.Add(auditrecord);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                if (string.IsNullOrWhiteSpace(_hostenvironment.WebRootPath))
                {
                    _hostenvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }
                string uploadsFolder = Path.Combine(_hostenvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        private bool IsImage(IFormFile Photo)
        {
            //-------------------------------------------
            //  Check the image mime types
            //-------------------------------------------
            if (!string.Equals(Photo.ContentType, "image/jpg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(Photo.ContentType, "image/jpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(Photo.ContentType, "image/png", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(Photo.ContentType, "image/jfif", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            //-------------------------------------------
            //  Check the image extension
            //-------------------------------------------
            var postedFileExtension = Path.GetExtension(Photo.FileName);
            if (!string.Equals(postedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".png", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".jfif", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return true;
        }
    }

}
