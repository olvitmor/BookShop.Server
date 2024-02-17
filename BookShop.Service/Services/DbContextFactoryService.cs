using System.Diagnostics;
using BookShop.DbContext;
using BookShop.Service.Interfaces;
using BookShop.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace BookShop.Service.Services;

public class DbContextFactoryService : IDbContextFactoryService
{
    private readonly SettingsProvider _settingsProvider;
    private readonly ILogger<DbContextFactoryService> _logger;

    public DbContextFactoryService(
        IConfiguration configuration,
        SettingsProvider settingsProvider,
        ILogger<DbContextFactoryService> logger)
    {
        _settingsProvider = settingsProvider;
        _logger = logger;
    }

    public AppDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(MakeConnectionString());
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.LogTo(x => _logger.LogInformation(x), new[] { RelationalEventId.CommandExecuting });
        return new AppDbContext(optionsBuilder.Options);
    }

    public string MakeConnectionString()
    {
        var options = _settingsProvider.DatabaseOptions;
        var connectionStringBuilder = new NpgsqlConnectionStringBuilder()
        {
            Host = options.POSTGRESQL_HOST,
            Port = options.POSTGRESQL_PORT,
            Database = options.POSTGRESQL_DBNAME,
            Username = options.POSTGRESQL_USER,
            Password = options.POSTGRESQL_PASSWORD
        };
        return connectionStringBuilder.ConnectionString;
    }

    public async void Migrate()
    {
        try
        {
            await using var dbContext = CreateDbContext();
            await dbContext.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "Error applying migrations");

            if (_settingsProvider.AppBehaviourOptions.FALL_IF_MIGRATION_FAILED)
                throw;
        }
    }

    public void MigrateAsync()
    {
        Task.Run(Migrate);
    }
}