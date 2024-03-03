using BookShop.Domain.Models.Api.Books;
using BookShop.Domain.Models.DbContext;

namespace BookShop.Service.Interfaces.Books;

public interface IBooksValidationService : IValidationService<BooksCreateOrUpdateParameters>
{
    
}