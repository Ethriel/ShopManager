using AutoMapper;
using ShopManager.Services.Model.DTO;

namespace ShopManager.Services.Model.Mapper
{
    public class ShopProduct : Profile
    {
        public ShopProduct()
        {
            CreateMap<ShopProduct, ShopProductDTO>();
            CreateMap<ShopProductDTO, ShopProduct>();
        }
    }
}
