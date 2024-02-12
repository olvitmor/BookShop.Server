using System.Linq.Expressions;
using BookShop.DbContext.Models.Books;
using BookShop.Domain.Extensions;

namespace BookShop.Domain.SearchParameters.Books;

public static class BooksSearchExpressionExtension
{
    public static Expression<Func<Book, bool>> GetExpression(this BooksSearchParameters parameters)
    {
        return ((Expression<Func<Book, bool>>)(x => true))
            .AddAndAlsoConditionWhenTrue(parameters.Ids is not null and { Length: > 0 },
                x => parameters.Ids!.Contains(x.Id));
    }
        
}