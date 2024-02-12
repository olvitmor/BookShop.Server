namespace BookShop.Service.Interfaces;

public interface IRepositoryService<TModel, in TSearchParameters, in TCreateOrUpdateParameters>
{
    public Task<ICollection<TModel>> Find(TSearchParameters parameters);

    public Task<TModel> Get(TSearchParameters parameters);

    public Task<(TModel, bool)> CreateOrUpdate(TModel model, TCreateOrUpdateParameters parameters);

    public Task<Guid> Delete(Guid id);
}