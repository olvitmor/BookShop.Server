using BookShop.Domain.Options;

namespace BookShop.Service.Interfaces;

public interface IOptionsService
{
    public PostgreSqlOptions PostgreSqlOptions { get; }
    
    public ApplicationOptions ApplicationOptions { get; }
}