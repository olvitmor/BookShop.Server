using BookShop.Domain.Options;
using BookShop.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Logging;

namespace BookShop.Service.Services;

public class MigrationMonitor : IMigrationMonitor
{
    public event EventHandler? OnDatabaseMigrationCompleted;

    private readonly ILogger<MigrationMonitor> _logger;
    private readonly IOptionsService _optionsService;
    private readonly IDbContextFactoryService _dbContextFactoryService;

    public MigrationMonitor(ILogger<MigrationMonitor> logger,
        IOptionsService optionsService,
        IDbContextFactoryService dbContextFactoryService)
    {
        _logger = logger;
        _optionsService = optionsService;
        _dbContextFactoryService = dbContextFactoryService;
    }

    public async void Migrate()
    {
        await using var dbContext = await _dbContextFactoryService.CreateDbContextAsync();

        var migrator = dbContext.Database.GetService<IMigrator>();

        foreach (var migration in await dbContext.Database.GetPendingMigrationsAsync())
        {
            await migrator.MigrateAsync(migration);
        }
        
        OnDatabaseMigrationCompleted?.Invoke(this, EventArgs.Empty);
    }

    public async Task MigrateAsync()
    {
        Task.Run(Migrate);
    }
}