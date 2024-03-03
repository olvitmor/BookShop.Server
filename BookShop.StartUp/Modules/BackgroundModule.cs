using BookShop.Service.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.StartUp.Modules;

public static class BackgroundModule
{
    public static WebApplication UseBackgroundModule(this WebApplication app)
    {
        var migrationMonitor = app.Services.GetRequiredService<IMigrationMonitor>();
        migrationMonitor.ApplyDatabaseMigrationEvents();
        migrationMonitor.MigrateAsync();

        return app;
    }

    private static IMigrationMonitor ApplyDatabaseMigrationEvents(this IMigrationMonitor migrationMonitor)
    {
        return migrationMonitor;
    }
}