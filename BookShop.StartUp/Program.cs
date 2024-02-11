using BookShop.StartUp.Extensions;
using Microsoft.AspNetCore.Builder;

namespace BookShop.StartUp;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.ConfigureServices();

        var app = builder.Build();
        
        app.ConfigureApp();

        app.Run();
    }
}