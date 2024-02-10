namespace BookShop.Api.Extensions;

/// <summary>
/// Startup extensions
/// </summary>
public static class StartupExtensions
{
    /// <summary>
    /// Configure services
    /// </summary>
    public static void ConfigureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers();
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();

        serviceCollection.AddSwaggerGen();
    }

    /// <summary>
    /// Configure application
    /// </summary>
    public static void ConfigureApp(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(o => { o.RoutePrefix = "swagger"; });
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();
    }
}