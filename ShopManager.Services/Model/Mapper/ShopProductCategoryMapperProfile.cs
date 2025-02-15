using AutoMapper;
using ShopManager.Database.Model;
using ShopManager.Services.Model.DTO;

namespace ShopManager.Services.Model.Mapper
{
    public class ShopProductCategoryMapperProfile : Profile
    {
        public ShopProductCategoryMapperProfile()
        {
            CreateMap<ShopProduct, ShopProductCategoryDTO>();
            CreateMap<ShopProductCategoryDTO, ShopProductCategory>();
        }
    }
}
