using BookShop.Domain.Enums;

namespace BookShop.Service.Interfaces;

public interface IRepositoryCreateService<TModel, in TCreateOrUpdateParameters>
{
    public Task<(TModel?, CreateOrUpdateResult)> CreateOrUpdate(TCreateOrUpdateParameters parameters, CancellationToken token);
}