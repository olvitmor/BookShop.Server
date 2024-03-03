using BookShop.Domain.Models.Api;
using BookShop.Domain.Models.Api.Books;
using BookShop.Domain.Models.DbContext;

namespace BookShop.Service.Interfaces.Books;

public interface IBooksRepositoryReadService : IRepositoryReadService<Book, BooksSearchParameters>
{
    
}