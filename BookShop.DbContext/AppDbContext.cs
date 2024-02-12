using BookShop.DbContext.Models.Books;
using BookShop.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookShop.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    private readonly SettingsProvider _settingsProvider;
    
    public DbSet<Book> Books { get; set; }

    public AppDbContext(SettingsProvider settingsProvider)
    {
        _settingsProvider = settingsProvider;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _settingsProvider.DatabaseOptions.GetConnectionString();
        optionsBuilder
            .UseNpgsql(connectionString)
            .LogTo(Console.WriteLine);
    }
}