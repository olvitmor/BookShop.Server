using BookShop.DbContext;
using BookShop.Service.Interfaces;
using BookShop.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.StartUp.Modules;

public static class DbContextModule
{
    public static WebApplicationBuilder AddDbContextModule(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddDbContext<AppDbContext>()
            .AddDbContextFactory<AppDbContext, DbContextFactoryService>()
            .AddSingleton<IDbContextFactoryService, DbContextFactoryService>();

        return builder;
    }
}