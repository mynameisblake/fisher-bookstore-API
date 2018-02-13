using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore; 

namespace Fisher.Bookstore.Api.Models
{
    public class BookstoreContext : DbContext 
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
            {

            }

            public DbSet<Book> Books {get; set;}
            public DbSet<Author> Authors {get; set;}
    }

}