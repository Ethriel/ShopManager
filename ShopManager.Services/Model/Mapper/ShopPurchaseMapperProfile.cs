using AutoMapper;
using ShopManager.Database.Model;
using ShopManager.Services.Model.DTO;
using ShopManager.Services.Model.Mapper.CustomResolvers;

namespace ShopManager.Services.Model.Mapper
{
    public class ShopPurchaseMapperProfile : Profile
    {
        public ShopPurchaseMapperProfile()
        {
            CreateMap<ShopPurchase, ShopPurchaseDTO>()
                .ForMember(dto => dto.Date, options => options.MapFrom(m => m.Date.ToShortDateString()))
                .ForMember(dto => dto.TotalPrice, options => options.MapFrom<PurchaseTotalPriceMapResolver>());

            CreateMap<ShopPurchaseDTO, ShopPurchase>()
                .ForMember(m => m.Date, options => options.MapFrom(dto => DateTime.Parse(dto.Date)))
                .ForMember(m => m.TotalPrice, options => options.Ignore());
        }
    }
}
