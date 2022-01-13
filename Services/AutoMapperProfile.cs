using AutoMapper;
using Domain.DTO;
using Domain.Model;

namespace Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, GetProductDTO>();
            CreateMap<AddProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();
        }
    }
}