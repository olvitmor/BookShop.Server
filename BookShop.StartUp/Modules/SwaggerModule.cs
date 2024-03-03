using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace BookShop.StartUp.Modules;

public static class SwaggerModule
{
    public static WebApplication UseSwaggerModule(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment()) return app;
        
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(o => { o.RoutePrefix = "swagger"; });

        return app;
    }
}