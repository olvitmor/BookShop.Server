using System.Linq.Expressions;
using BookShop.Domain.Enums;
using BookShop.Domain.Interfaces;

namespace BookShop.Service.Interfaces;

public interface IRepository
{
    public Task<bool> Exists<TModel>(Expression<Func<TModel, bool>> filter, CancellationToken token)
        where TModel : class;

    public Task<ICollection<TModel>> Find<TModel>(Expression<Func<TModel, bool>> filter, CancellationToken token)
        where TModel : class;

    public Task<TModel> Get<TModel>(Expression<Func<TModel, bool>> filter, CancellationToken token)
        where TModel : class;

    public Task<(TModel?, CreateOrUpdateResult)> CreateOrUpdate<TModel>(Guid guid, TModel model,
        CancellationToken token)
        where TModel : class, IHasId;

    public Task<(ICollection<Guid>?, DeleteResult)> Delete<TModel>(Expression<Func<TModel, bool>> filter,
        CancellationToken token)
        where TModel : class, IHasId;
}