using BookShop.Service.Interfaces;
using Microsoft.AspNetCore.Builder;

namespace BookShop.StartUp.Modules;

public static class BackgroundModule
{
    public static WebApplication AddBackgroundModule(this WebApplication app)
    {
        var dbContextFactoryService =
            (IDbContextFactoryService)app.Services.GetService(typeof(IDbContextFactoryService))!;
        dbContextFactoryService.MigrateAsync();

        return app;
    }
}