using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesMovieContext>>()))
            {
                // Look for any movies.
                if (context.Listings.Any())
                {
                    return;
                }
                context.Listings.AddRange(
                    new Listing
                    {
                        itemName = "White keyboard",
                        weight = 2.5,
                        price = 120,
                        colour = "white",
                        imageName = "whiteKeyboard",
                        itemType = "Keyboard",
                        content = "8828ed40-7ce8-41a3-b954-510bc36defa2.jpg"
                    },

                    new Listing
                    {
                        itemName = "Black keyboard",
                        weight = 3.5,
                        price = 140,
                        colour = "black",
                        imageName = "blackKeyboard",
                        itemType = "Keyboard",
                        content = "1c2b2438-cd6a-46db-9dd4-d8c68183d4b6.jpg"
                    }
                    );

                context.SaveChanges();


            }
        }
    }
}