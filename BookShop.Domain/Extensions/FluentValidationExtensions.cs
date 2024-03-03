namespace BookShop.Domain.Extensions;

public static class FluentValidationExtensions
{
    public static string[] ToSimpleStringArray(this FluentValidation.ValidationException e)
    {
        return e.Errors
            .Select(x => $"Property:{x.PropertyName} Message: {x.ErrorMessage}")
            .ToArray();
    } 
}