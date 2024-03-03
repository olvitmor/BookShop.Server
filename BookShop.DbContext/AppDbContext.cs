using BookShop.Domain.Models.DbContext;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Book> Books { get; init; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}