using BookShop.DbContext;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Service.Interfaces;

public interface IDbContextFactoryService : IDbContextFactory<AppDbContext>
{
    public void Migrate();

    public void MigrateAsync();

    public string MakeConnectionString();
}