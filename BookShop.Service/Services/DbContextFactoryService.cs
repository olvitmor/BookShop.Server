using BookShop.DbContext;
using BookShop.Domain.Options;
using BookShop.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace BookShop.Service.Services;

public class DbContextFactoryService : IDbContextFactoryService
{
    private readonly ILogger<DbContextFactoryService> _logger;
    private readonly PostgreSqlOptions _postgreSqlOptions;

    public DbContextFactoryService(IOptionsService optionsService, ILogger<DbContextFactoryService> logger)
    {
        _postgreSqlOptions = optionsService.PostgreSqlOptions;
        _logger = logger;
    }

    public AppDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(_postgreSqlOptions.ConnectionString);
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.LogTo(x => _logger.LogInformation(x), new[] { RelationalEventId.CommandExecuting });
        return new AppDbContext(optionsBuilder.Options);
    }
}