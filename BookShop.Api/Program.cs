using BookShop.Api.Extensions;

namespace BookShop.Api;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.ConfigureServices();

        var app = builder.Build();
        
        app.ConfigureApp();

        app.Run();
    }
}