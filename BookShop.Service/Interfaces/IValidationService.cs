namespace BookShop.Service.Interfaces;

public interface IValidationService<TModel>
{
    /// <summary>
    /// Validation method, that throws an exception
    /// if model is not valid.
    /// </summary>
    public void ThrowIfNotValid(TModel model);

    /// <summary>
    /// Validation method that returns a Boolean
    /// value of the validity of the model.
    /// </summary>
    /// <returns>True - if model is valid, otherwise - False</returns>
    public bool IsValid(TModel model);
}