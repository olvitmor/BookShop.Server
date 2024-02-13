using BookShop.StartUp.Extensions;
using Microsoft.AspNetCore.Builder;

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
            .RunBackgroundJobs();
        
        app.Run();
    }
}