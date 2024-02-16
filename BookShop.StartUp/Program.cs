using BookShop.StartUp.Modules;
using Microsoft.AspNetCore.Builder;

namespace BookShop.StartUp;

public static class Program
{
    public static void Main(string[] args)
    {
        var app = WebApplication
            .CreateBuilder(args)
            .AddStartupModule()
            .AddSettingsModule()
            .AddDbContextModule()
            .AddMapperModule()
            .AddRepositoryModule()
            .Build();

        app.AddSwaggerModule();

        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();

        app.AddBackgroundModule();
        
        app.Run();
    }
}