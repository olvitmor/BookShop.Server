using BookShop.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.StartUp.Modules;

public static class MapperModule
{
    public static WebApplicationBuilder AddMapperModule(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(Mapper.MappingProfile));
        
        return builder;
    }
}