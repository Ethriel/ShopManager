using AutoMapper;
using ShopManager.Database.Model;
using ShopManager.Services.Model.DTO;

namespace ShopManager.Services.Model.Mapper
{
    public class ShopProductMapperProfile : Profile
    {
        public ShopProductMapperProfile()
        {
            CreateMap<ShopProduct, ShopProductDTO>();
            CreateMap<ShopProductDTO, ShopProduct>();
        }
    }
}
