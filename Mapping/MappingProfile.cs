using AutoMapper;
using CoffeeMug.Models;
namespace CoffeeMug.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductCreateInputModel, Product>();
            CreateMap<ProductUpdateInputModel, Product>();

        }
    }
}