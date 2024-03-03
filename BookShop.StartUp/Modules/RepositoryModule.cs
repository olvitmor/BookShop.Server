using BookShop.Domain.Models.Api.Books;
using BookShop.Service.Interfaces;
using BookShop.Service.Interfaces.Books;
using BookShop.Service.Services;
using BookShop.Service.Services.Books;
using BookShop.Service.Services.Books.CreateOrUpdate;
using BookShop.Service.Services.Books.Delete;
using BookShop.Service.Services.Books.Read;
using BookShop.Service.Services.Books.Validate;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.StartUp.Modules;

public static class RepositoryModule
{
    public static WebApplicationBuilder UseRepositoryModule(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddSingleton<IRepository, RepositoryService>()
            .AddReadServices()
            .AddDeleteServices()
            .AddValidationServices()
            .AddCreateServices();
        
        return builder;
    }

    private static IServiceCollection AddValidationServices(this IServiceCollection services)
    {
        services.AddScoped<IValidator<BooksCreateOrUpdateParameters>, BooksCreateOrUpdateValidator>();
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
        services.AddScoped<IBooksRepositoryCreateOrUpdateService, BooksRepositoryCreateOrUpdateService>();
        
        return services;
    }

    private static IServiceCollection AddDeleteServices(this IServiceCollection services)
    {
        services.AddScoped<IBooksRepositoryDeleteService, BooksRepositoryDeleteService>();
        
        return services;
    }
    
}