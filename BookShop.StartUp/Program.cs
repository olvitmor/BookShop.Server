using BookShop.StartUp.Modules;
using Microsoft.AspNetCore.Builder;

namespace BookShop.StartUp;

public static class Program
{
    public static void Main(string[] args)
    {
        var app = WebApplication
            .CreateBuilder(args)
            .UseStartupModule()
            .UseOptionsModule()
            .UseDbContextModule()
            .UseMapperModule()
            .UseRepositoryModule()
            .Build();

        app.UseSwaggerModule();

        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();

        app.UseBackgroundModule();
        
        app.Run();
    }
}