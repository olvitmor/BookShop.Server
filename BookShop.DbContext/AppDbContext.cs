using BookShop.DbContext.Models.Books;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Book> Books { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}