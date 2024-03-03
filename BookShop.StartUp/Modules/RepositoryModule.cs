using BookShop.Service.Interfaces;
using BookShop.Service.Interfaces.Books;
using BookShop.Service.Services;
using BookShop.Service.Services.Books;
using BookShop.Service.Services.Books.Create;
using BookShop.Service.Services.Books.Delete;
using BookShop.Service.Services.Books.Read;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.StartUp.Modules;

public static class RepositoryModule
{
    public static WebApplicationBuilder UseRepositoryModule(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddSingleton<IRepository, RepositoryService>()
            .AddValidationServices()
            .AddReadServices()
            .AddCreateServices()
            .AddDeleteServices();
        
        return builder;
    }

    private static IServiceCollection AddValidationServices(this IServiceCollection services)
    {
        services.AddScoped<IBooksValidationService, BooksValidationService>();

        return services;
    }

    private static IServiceCollection AddReadServices(this IServiceCollection services)
    {
        services.AddScoped<IBooksRepositoryReadService, BooksRepositoryReadService>();
        
        return services;
    }

    private static IServiceCollection AddCreateServices(this IServiceCollection services)
    {
        services.AddScoped<IBooksRepositoryCreateService, BooksRepositoryCreateService>();
        
        return services;
    }

    private static IServiceCollection AddDeleteServices(this IServiceCollection services)
    {
        services.AddScoped<IBooksRepositoryDeleteService, BooksRepositoryDeleteService>();
        
        return services;
    }
    
}