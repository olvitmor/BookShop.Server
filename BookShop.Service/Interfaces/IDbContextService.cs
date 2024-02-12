using BookShop.DbContext;

namespace BookShop.Service.Interfaces;

public interface IDbContextService
{
    public Task<AppDbContext> GetDbContext();

    public Task InitAsync();
}