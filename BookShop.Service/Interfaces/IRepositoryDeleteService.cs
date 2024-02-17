using BookShop.Domain.Enums;

namespace BookShop.Service.Interfaces;

public interface IRepositoryDeleteService<in TDeleteParameters>
{
    public Task<(ICollection<Guid>?, DeleteResult)> Delete(TDeleteParameters parameters, CancellationToken token);
}