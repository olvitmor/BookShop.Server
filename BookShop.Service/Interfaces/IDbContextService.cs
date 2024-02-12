using BookShop.DbContext;

namespace BookShop.Service.Interfaces;

public interface IDbContextService
{
    public AppDbContext GetDbContext();

    public Task InitAsync();
}