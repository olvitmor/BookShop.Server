using BookShop.DbContext.Models.Books;
using BookShop.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookShop.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    private readonly IConfiguration _configuration;
    private readonly SettingsProvider _settingsProvider;
    
    public DbSet<Book> Books { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options,
        IConfiguration configuration,
        SettingsProvider settingsProvider) : base(options)
    {
        _configuration = configuration;
        _settingsProvider = settingsProvider;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _settingsProvider.DbSettings.GetConnectionString();
        optionsBuilder.UseNpgsql(connectionString);
    }
}