using BookShop.Domain.Options;
using BookShop.Service.Interfaces;
using Microsoft.Extensions.Options;

namespace BookShop.Service.Services;

public class OptionsService : IOptionsService
{
    public PostgreSqlOptions PostgreSqlOptions { get; }
    public ApplicationOptions ApplicationOptions { get; }

    public OptionsService(
        IOptions<PostgreSqlOptions> postgreSqlOptions,
        IOptions<ApplicationOptions> applicationOptions)
    {
        PostgreSqlOptions = postgreSqlOptions.Value;
        ApplicationOptions = applicationOptions.Value;
    }
}