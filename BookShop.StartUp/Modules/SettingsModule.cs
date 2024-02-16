using BookShop.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.StartUp.Modules;

public static class SettingsModule
{
    public static WebApplicationBuilder AddSettingsModule(this WebApplicationBuilder builder)
    {
        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

        builder.Configuration.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: false);

        builder.Services.AddSingleton<SettingsProvider>();

        return builder;
    }
}