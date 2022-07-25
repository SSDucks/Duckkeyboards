using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie;
using RazorPagesMovie.Data;
using System.Web;
using Microsoft.AspNetCore.Hosting;

namespace RazorPagesMovie.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;
        private readonly IWebHostEnvironment _hostenvironment;

        public CreateModel(RazorPagesMovie.Data.RazorPagesMovieContext context,
            IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostenvironment = hostEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Item Item { get; set; }
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

            // Adding image to folder
            // I HAVE NO IDEA WHAT ANY OF THIS DOES 
            if(FileUpload.FormFile.Length > 0)
            {
                using (var stream = new FileStream(Path.Combine(_hostenvironment.WebRootPath
                    , "uploadfiles", FileUpload.FormFile.FileName),FileMode.Create))
                {
                    await FileUpload.FormFile.CopyToAsync(stream);
                }
            }
            // Sae image to database
            using(var memoryStream = new MemoryStream())
            {
                await FileUpload.FormFile.CopyToAsync(memoryStream);

                // Upload file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    Item.Content = memoryStream.ToArray();
                }
            }

            _context.Item.Add(Item);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
