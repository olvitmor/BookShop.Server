using BookShop.Api;
using BookShop.DbContext;
using BookShop.DbContext.Models.Books;
using BookShop.Domain.CreateOrUpdateParameters.Books;
using BookShop.Domain.SearchParameters.Books;
using BookShop.Service.Interfaces;
using BookShop.Service.Services;
using BookShop.Service.Services.Books;
using BookShop.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookShop.StartUp.Extensions;

/// <summary>
/// Startup extensions
/// </summary>
public static class StartupExtensions
{
    public static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder)
    {
        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

        builder.Configuration.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: false);
        
        return builder;
    }
    
    /// <summary>
    /// Configure services
    /// </summary>
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers()
            .AddNewtonsoftJson()
            .AddApplicationPart(typeof(BookShopApiModule).Assembly);

        builder.Services.AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddAutoMapper(typeof(AppMappingProfile))
            .AddSingleton<SettingsProvider>()
            .AddDbContext<AppDbContext>()
            .AddDbContextFactory<AppDbContext, DbContextFactoryService>()
            .AddSingleton<IDbContextFactoryService, DbContextFactoryService>()
            .AddSingleton<IRepository, RepositoryService>()
            .AddSingleton<IRepositoryReadService<Book, BooksSearchParameters, BooksCreateOrUpdateParameters>,BooksRepositoryReadReadService>()
            .AddSingleton<IValidationService<Book>, BooksValidationService>();

        return builder;
    }

    /// <summary>
    /// Configure application
    /// </summary>
    public static WebApplication ConfigureApp(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(o => { o.RoutePrefix = "swagger"; });
        }

        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }

    /// <summary>
    /// Run background services
    /// </summary>
    public static WebApplication RunBackgroundJobs(this WebApplication app)
    {
        var dbContextFactoryService = (IDbContextFactoryService)app.Services.GetService(typeof(IDbContextFactoryService))!;
        dbContextFactoryService.MigrateAsync();

        return app;
    }
}