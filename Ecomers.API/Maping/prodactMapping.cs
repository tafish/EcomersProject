using AutoMapper;
using Ecom.Cor.Entites.Product;
using Ecomers.Cor.DTO;

namespace Ecomers.API.Maping
{
    public class prodactMapping : Profile
    {

        public prodactMapping()
        {
            CreateMap<Product, ProductDTO>().ForMember(p => p.CatagoryName
            , op => op.MapFrom(sc => sc.Catagory.Name)).ReverseMap();
            CreateMap<AddProductDTO, Product>()
                .ForMember(m => m.Photos, op => op.Ignore())
                .ReverseMap();
            CreateMap<UpdetProductDTO, Product>()
                .ForMember(m => m.Photos, op => op.Ignore())
                .ReverseMap();
        }
    }
}
