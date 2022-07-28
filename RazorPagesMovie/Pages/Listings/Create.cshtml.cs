using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Listings
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;
        private readonly IWebHostEnvironment _hostenvironment;

        public CreateModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //FileUpload file to folder
            if(FileUpload.FormFile.Length > 0)
            {
                if (string.IsNullOrWhiteSpace(_hostenvironment.WebRootPath)){
                    _hostenvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }
                using (var stream = new FileStream(Path.Combine(_hostenvironment.WebRootPath, "uploadFiles", FileUpload.FormFile.FileName), FileMode.Create))
                {
                    await FileUpload.FormFile.CopyToAsync(stream);
                }

            }

            // Save image to database
            using (var memoryStream = new MemoryStream()){
                await FileUpload.FormFile.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if(memoryStream.Length < 2097152)
                {
                    Listing.imageName = FileUpload.FormFile.FileName;
                    Listing.content = memoryStream.ToArray();

                    _context.Listings.Add(Listing);
                    await _context.SaveChangesAsync();
        
                    return RedirectToPage("./Index");
                }
                else
                {
                    ModelState.AddModelError("File", "File should be less than 2 MB");
                }
            }
            return RedirectToPage("./Index");
        }
    }
}
