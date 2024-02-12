using BookShop.StartUp.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace BookShop.StartUp;

public static class Program
{
    public static void Main(string[] args)
    {
        var app = WebApplication
            .CreateBuilder(args)
            .ConfigureBuilder()
            .ConfigureServices()
            .Build()
            .ConfigureApp()
            .RunBackgroundServices();
        
        app.Run();
    }
}