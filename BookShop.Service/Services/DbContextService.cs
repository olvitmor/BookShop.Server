using BookShop.DbContext;
using BookShop.Service.Interfaces;
using BookShop.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace BookShop.Service.Services;

public class DbContextService : IDbContextService
{
    private readonly SettingsProvider _settingsProvider;
    private readonly ILogger<DbContextService> _logger;
    
    public DbContextService(IConfiguration configuration, 
        SettingsProvider settingsProvider,
        ILogger<DbContextService> logger)
    {
        _settingsProvider = settingsProvider;
        _logger = logger;
    }

    public async Task<AppDbContext> CreateDbContext()
    {
        await ThrowIfDbIsNotAvailable();
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(_settingsProvider.DatabaseOptions.GetConnectionString());
        optionsBuilder.LogTo(Console.WriteLine);
        return new AppDbContext(optionsBuilder.Options);
    }

    public async Task Init()
    {
        await ThrowIfDbIsNotAvailable();
        await using var dbContext = await CreateDbContext();
        await dbContext.Database.MigrateAsync();
    }

    private async Task ThrowIfDbIsNotAvailable()
    {
        var connectionString = _settingsProvider.DatabaseOptions.GetConnectionString();
        try
        {
            await using var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync();
            await connection.CloseAsync();
            return;
        }
        catch (Exception ex)
        {
            _logger.LogCritical(message: "Database is not available");
            throw;
        }
    }
}