using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Domain.Entites;

namespace CleanArchMVC.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
