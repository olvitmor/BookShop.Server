using BookShop.Domain.Models.Api;
using BookShop.Domain.Models.Api.Books;

namespace BookShop.Service.Interfaces.Books;

public interface IBooksRepositoryDeleteService : IRepositoryDeleteService<BooksDeleteParameters>
{
    
}