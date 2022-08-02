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
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }
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

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();


            }
        }
    }
}