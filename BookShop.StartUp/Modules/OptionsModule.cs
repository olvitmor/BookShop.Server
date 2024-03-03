using BookShop.Domain.Options;
using BookShop.Service.Interfaces;
using BookShop.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.StartUp.Modules;

public static class OptionsModule
{
    public static WebApplicationBuilder UseOptionsModule(this WebApplicationBuilder builder)
    {
        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

        builder.Configuration.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: false);

        builder.Services.Configure<PostgreSqlOptions>(builder.Configuration.GetSection(PostgreSqlOptions.OptionsKey));
        
        builder.Services.Configure<ApplicationOptions>(builder.Configuration.GetSection(ApplicationOptions.OptionsKey));

        builder.Services.AddSingleton<IOptionsService, OptionsService>();

        return builder;
    }
}