using System.Linq.Expressions;
using BookShop.DbContext.Interfaces;
using BookShop.Domain.Enums;

namespace BookShop.Service.Interfaces;

public interface IRepository
{
    public Task<bool> Exists<TModel>(Expression<Func<TModel, bool>> filter, CancellationToken token)
        where TModel : class;

    public Task<List<TModel>> Find<TModel>(Expression<Func<TModel, bool>> filter, CancellationToken token)
        where TModel : class;

    public Task<TModel> Get<TModel>(Expression<Func<TModel, bool>> filter, CancellationToken token)
        where TModel : class;

    public Task<(TModel?, CreateOrUpdateResult)> CreateOrUpdate<TModel>(Guid guid, TModel model, CancellationToken token)
        where TModel : class, IHasId;

    public Task<(TModel, bool, string)> Delete<TModel>(Guid id, CancellationToken token)
        where TModel : class;
}