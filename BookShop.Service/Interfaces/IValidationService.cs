namespace BookShop.Service.Interfaces;

public interface IValidationService<TModel>
{
    /// <summary>
    /// Validation method, that throws an exception
    /// if model is not valid.
    /// </summary>
    public Task ThrowIfNotValid(TModel model, CancellationToken token);

    /// <summary>
    /// Validation method that returns a Boolean
    /// value of the validity of the model.
    /// </summary>
    /// <returns>True - if model is valid, otherwise - False</returns>
    public Task<bool> IsValid(TModel model, CancellationToken token);
}