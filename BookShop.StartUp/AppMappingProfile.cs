using AutoMapper;
using BookShop.DbContext.Models.Books;

namespace BookShop.StartUp;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<Book, Book>();
    }
}