using System.Linq.Expressions;
using AutoMapper;
using BookShop.DbContext;
using BookShop.Domain.Enums;
using BookShop.Domain.Interfaces;
using BookShop.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookShop.Service.Services;

public class RepositoryService : IRepository
{
    private readonly ILogger<RepositoryService> _logger;
    private readonly IDbContextFactory<AppDbContext> _dbContextFactoryService;
    private readonly IMapper _mapper;

    public RepositoryService(ILogger<RepositoryService> logger,
        IDbContextFactory<AppDbContext> dbContextFactoryService,
        IMapper mapper)
    {
        _logger = logger;
        _dbContextFactoryService = dbContextFactoryService;
        _mapper = mapper;
    }

    public Task<bool> Exists<TModel>(Expression<Func<TModel, bool>> filter, CancellationToken token)
        where TModel : class
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<TModel>> Find<TModel>(Expression<Func<TModel, bool>> filter, CancellationToken token)
        where TModel : class
    {
        try
        {
            await using var dbContext = await _dbContextFactoryService.CreateDbContextAsync(token);

            return await dbContext.Set<TModel>().Where(filter).ToListAsync(token);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex, $"Error processing {nameof(Find)} request");
        }

        return [];
    }

    public Task<TModel> Get<TModel>(Expression<Func<TModel, bool>> filter, CancellationToken token) where TModel : class
    {
        throw new NotImplementedException();
    }

    public async Task<(TModel?, CreateOrUpdateResult)> CreateOrUpdate<TModel>(Guid guid, TModel model,
        CancellationToken token)
        where TModel : class, IHasId
    {
        TModel? entity = null;
        var actionResult = CreateOrUpdateResult.None;
        try
        {
            await using var dbContext = await _dbContextFactoryService.CreateDbContextAsync(token);
            var entityInDb = await dbContext.Set<TModel>().FirstOrDefaultAsync(x => x.Id == model.Id, token);
            if (entityInDb != null)
            {
                entityInDb = (TModel)_mapper.Map(model, entityInDb, typeof(TModel), typeof(TModel));
                actionResult = CreateOrUpdateResult.Updated;
            }
            else
            {
                entityInDb = (TModel)_mapper.Map(model, typeof(TModel), typeof(TModel));
                await dbContext.Set<TModel>().AddAsync(entityInDb, token);
                actionResult = CreateOrUpdateResult.Created;
            }

            await dbContext.SaveChangesAsync(token);
            entity = entityInDb;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex, $"Error processing {nameof(CreateOrUpdate)} request");
            actionResult = CreateOrUpdateResult.Error;
        }

        return (entity, actionResult);
    }

    public async Task<(ICollection<Guid>?, DeleteResult)> Delete<TModel>(Expression<Func<TModel, bool>> filter,
        CancellationToken token)
        where TModel : class, IHasId
    {
        var actionResult = DeleteResult.None;
        try
        {
            await using var dbContext = await _dbContextFactoryService.CreateDbContextAsync(token);

            var entities = await dbContext.Set<TModel>().Where(filter).ToListAsync(token);

            var ids = entities.Select(x => x.Id).ToList();

            dbContext.Set<TModel>().RemoveRange(entities);

            await dbContext.SaveChangesAsync(token);

            return (ids, DeleteResult.Success);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex, $"Error processing {nameof(CreateOrUpdate)} request");
            actionResult = DeleteResult.Error;
        }

        return ([], actionResult);
    }
}