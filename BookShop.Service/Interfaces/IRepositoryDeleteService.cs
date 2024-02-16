namespace BookShop.Service.Interfaces;

public interface IRepositoryDeleteService<in TDeleteParameters>
{
    public Task<Guid> Delete(TDeleteParameters parameters, CancellationToken token);

    public Task<List<Guid>> DeleteBulk(TDeleteParameters parameters, CancellationToken token);
}