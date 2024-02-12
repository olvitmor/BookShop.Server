namespace BookShop.Service.Interfaces;

public interface IRepositoryService<TModel, in TSearchParameters, in TCreateOrUpdateParameters>
{
    public Task<ICollection<TModel>> Find(TSearchParameters parameters, CancellationToken token);

    public Task<TModel> Get(TSearchParameters parameters, CancellationToken token);

    public Task<(TModel, bool)> CreateOrUpdate(TCreateOrUpdateParameters parameters, CancellationToken token);

    public Task<Guid> Delete(Guid id, CancellationToken token);
}