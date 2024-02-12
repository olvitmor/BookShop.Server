using BookShop.DbContext;
using BookShop.Service.Interfaces;
using BookShop.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BookShop.Service.Services;

public class DbContextService : IDbContextService
{
    private readonly IConfiguration _configuration;
    private readonly SettingsProvider _settingsProvider;
    private readonly ILogger<DbContextService> _logger;
    
    public DbContextService(IConfiguration configuration, 
        SettingsProvider settingsProvider,
        ILogger<DbContextService> logger)
    {
        _configuration = configuration;
        _settingsProvider = settingsProvider;
        _logger = logger;
    }

    public Task<AppDbContext> GetDbContext()
    {
        throw new NotImplementedException();
    }

    public async Task InitAsync()
    {
        await using var dbContext = new AppDbContext(_settingsProvider);

        await dbContext.Database.MigrateAsync();
    }
}