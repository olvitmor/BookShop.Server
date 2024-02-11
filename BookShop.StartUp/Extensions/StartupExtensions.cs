using BookShop.Api;
using BookShop.DbContext;
using BookShop.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookShop.StartUp.Extensions;

/// <summary>
/// Startup extensions
/// </summary>
public static class StartupExtensions
{
    /// <summary>
    /// Configure services
    /// </summary>
    public static void ConfigureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers()
            .AddApplicationPart(typeof(BookShopApiModule).Assembly);
        
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();

        serviceCollection.AddSwaggerGen();

        serviceCollection.AddSingleton<SettingsProvider>();
    }

    /// <summary>
    /// Configure application
    /// </summary>
    public static void ConfigureApp(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(o => { o.RoutePrefix = "swagger"; });
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();
    }
}