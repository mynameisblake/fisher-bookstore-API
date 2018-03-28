using Fisher.Bookstore.Api.Models;
using Microsoft.EntityFrameworkCore; 

namespace Fisher.Bookstore.Api.Data
{
    public class BookstoreContext : DbContext 
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
            {
                // delete constructor code that seeded our data
            }

            protected override void OnModelCreating(ModelBuilder builder) => base
    .OnModelCreating(builder);

            public DbSet<Book> Books {get; set;}
            public DbSet<Author> Authors {get; set;}
    }

}