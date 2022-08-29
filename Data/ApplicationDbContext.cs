using CG_VAK_BooksWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CG_VAK_BooksWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>  options ) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; } 

    }
}
