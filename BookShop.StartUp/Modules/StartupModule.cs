using BookShop.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.StartUp.Modules;

public static class StartupModule
{
    public static WebApplicationBuilder UseStartupModule(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddControllers()
            .AddNewtonsoftJson()
            .AddApplicationPart(typeof(BookShopApiModule).Assembly);

        builder.Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();

        return builder;
    }
}