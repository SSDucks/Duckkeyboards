using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie;
using RazorPagesMovie.Data;
using System.ComponentModel.DataAnnotations;


namespace RazorPagesMovie.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        //public async Task OnGetAsync()
        //{
        //    Item = await _context.Item.ToListAsync();
        //}
        public async Task OnGetAsync()
        {
            var items = from i in _context.Item select i;
            if (!string.IsNullOrEmpty(SearchString))
            {
                items = items.Where(s => s.itemName.Contains(SearchString));
            }

            Item = await items.ToListAsync();
        }
    }
}
