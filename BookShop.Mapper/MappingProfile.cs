using AutoMapper;
using BookShop.Domain.Models.Api.Books;
using BookShop.Domain.Models.DbContext;

namespace BookShop.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, Book>().ReverseMap();
        CreateMap<BooksCreateOrUpdateParameters, Book>();
    }
}