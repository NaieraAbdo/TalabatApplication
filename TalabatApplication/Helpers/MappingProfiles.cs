using AutoMapper;
using Talabat.Core.Entities;
using TalabatApplication.DTOs;

namespace TalabatApplication.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(d => d.ProductType,O => O.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.ProductBrand,O => O.MapFrom(s => s.ProductBrand.Name));
        }
    }
}
