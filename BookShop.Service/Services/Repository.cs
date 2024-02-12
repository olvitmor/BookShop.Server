using System.Data.Common;
using BookShop.DbContext.Models.Books;
using BookShop.Domain.Enums;
using BookShop.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookShop.Service.Services;

public class Repository : IRepository
{
    private ILogger<Repository> _logger;
    
    public Repository(ILogger<Repository> logger)
    {
        _logger = logger;
    }
    
    public async Task<bool> ExecuteAsync<TModel>(Func<Task> func)
    {
        try
        {
            await func();
            return true;
        }
        catch (DbUpdateException updateException)
        {
            _logger.LogError($"Error updating instance {nameof(TModel)}: {updateException.Message}");
        }
        catch (DbException dbException)
        {
            _logger.LogError(dbException.InnerException?.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return false;
    }
}