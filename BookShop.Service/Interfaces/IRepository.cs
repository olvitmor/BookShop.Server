namespace BookShop.Service.Interfaces;

public interface IRepository
{
    public Task<bool> ExecuteAsync<TModel>(Func<Task> func);
}