using AutoMapper;
using BookShop.Domain.Models.Books;

namespace BookShop.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, Book>();
    }
}