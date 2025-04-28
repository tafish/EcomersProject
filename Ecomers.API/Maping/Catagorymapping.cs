using AutoMapper;
using Ecom.Cor.Entites.Product;
using Ecomers.Cor.DTO;

namespace Ecomers.API.Maping
{
    public class Catagorymapping : Profile
    {
        public Catagorymapping()
        {
            CreateMap<CatagoryDTO, Catagory>().ReverseMap();
            CreateMap<UpdetCatagoryDTO, Catagory>().ReverseMap();
        }
    }
}
