using AutoMapper;
using WebStyle.ProductApi.Models;

namespace WebStyle.ProductApi.DTOs.Mappings;

public class MappingsProfile : Profile
{
    public MappingsProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}
