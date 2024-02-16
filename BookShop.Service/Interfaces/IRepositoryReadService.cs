using BookShop.Domain.Enums;

namespace BookShop.Service.Interfaces;

public interface IRepositoryReadService<TModel, in TSearchParameters>
{
    public Task<ICollection<TModel>> Find(TSearchParameters parameters, CancellationToken token);

    public Task<TModel> Get(TSearchParameters parameters, CancellationToken token);
}