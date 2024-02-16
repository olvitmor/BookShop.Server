using BookShop.Domain.Models.Books;

namespace BookShop.Service.Interfaces.Books;

public interface IBooksRepositoryReadService : IRepositoryReadService<Book, BooksSearchParameters>
{
    
}