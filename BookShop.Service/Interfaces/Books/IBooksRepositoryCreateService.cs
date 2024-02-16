using BookShop.Domain.Models.Books;

namespace BookShop.Service.Interfaces.Books;

public interface IBooksRepositoryCreateService : IRepositoryCreateService<Book, BooksCreateOrUpdateParameters>
{
    
}