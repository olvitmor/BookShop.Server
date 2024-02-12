using System.Linq.Expressions;
using BookShop.DbContext.Models.Books;

namespace BookShop.Domain.SearchParameters.Books;

public static class BooksSearchExpressionExtension
{
    public static Expression<Func<Book, bool>> GetExpression(this BooksSearchParameters parameters)
    {
        return x => true;
    }
        
}