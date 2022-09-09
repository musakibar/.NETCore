
using System;
using System.Linq;
using WebApi.Common;
using WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                // Look for any board games.
                if (context.Books.Any())
                {
                    return;   // Data was already seeded
                }

                context.Genres.AddRange(
                    new Genre()
                    {
                        Name = "Personal Growth"
                    },
                    new Genre()
                    {
                        Name = "Science Fiction"
                    },
                    new Genre()
                    {
                        Name = "Romance"
                    }
                );                

                context.Books.AddRange(
                   new Book()
                   {
                       Title = "Lean Startup",
                       GenreId = 1,
                       AuthorId = 1,
                       PageCount = 200,
                       PublishDate = new DateTime(2001, 06, 12)
                   },
                    new Book()
                    {
                        Title = "Herland",
                        GenreId = 2,
                        AuthorId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2002, 06, 12)
                    },
                    new Book()
                    {
                        Title = "Dune",
                        GenreId = 2,
                        AuthorId = 3,
                        PageCount = 540,
                        PublishDate = new DateTime(2002, 05, 23)
                    });

                if (context.Authors.Any())
                {
                    return;   // Data was already seeded
                }

                context.Authors.AddRange(
                    new Author()
                    {                        
                        Name = "Oğuz",
                        Surname =  "Atay",
                        BirthDate = new DateTime(1984,10,12)
                    },
                    new Author()
                    {
                        Name = "Orhan",
                        Surname = "Pamuk",
                        BirthDate = new DateTime(1984,10,12)
                    },
                    new Author()
                    {
                        Name = "Ömer",
                        Surname = "Seyfettin",
                        BirthDate = new DateTime(1984,10,12)
                    }
                );


                context.SaveChanges();
            }
        }
    }
}