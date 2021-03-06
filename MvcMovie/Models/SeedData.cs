using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Ephraim's Rescue",
                        ReleaseDate = DateTime.Parse("2013-5-31"),
                        Genre = "Drama",
                        Rating = "PG-13",
                        Price = 7.99M
                        
                    },

                    new Movie
                    {
                        Title = "Saturdy's Warrior",
                        ReleaseDate = DateTime.Parse("2016-4-01"),
                        Genre = "Musical",
                        Rating = "PG",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "Passage to Zarahemla",
                        ReleaseDate = DateTime.Parse("2007-10-15"),
                        Genre = "Adventure",
                        Rating = "PG-13",
                        Price = 6M

                    },
                    new Movie
                    {
                        Title = "Meet the Mormons",
                        ReleaseDate = DateTime.Parse("2014-10-10"),
                        Genre = "Documentary",
                        Rating = "PG",
                        Price = 2.51M

                    }

                );
                context.SaveChanges();
            }
        }
    }
}