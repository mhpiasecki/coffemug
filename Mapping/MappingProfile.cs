using AutoMapper;
using CoffeeMug.Models;
namespace CoffeeMug.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductCreateInputModel, Product>();
            CreateMap<ProductUpdateInputModel, Product>()
            .ForMember(inp => inp.Id, prod => prod.Ignore())
            .ForMember(inp => inp.Name, prod => prod.MapFrom(inpD => inpD.Name))
            .ForMember(inp => inp.Price, prod => prod.MapFrom(inpD => inpD.Price));

        }
    }
}