using BookShop.DbContext;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Service.Interfaces;

public interface IDbContextFactoryService : IDbContextFactory<AppDbContext>
{

}