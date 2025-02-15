using AutoMapper;
using ShopManager.Database.Model;
using ShopManager.Services.Model.DTO;

namespace ShopManager.Services.Model.Mapper
{
    public class ShopPurchaseMapperProfile : Profile
    {
        public ShopPurchaseMapperProfile()
        {
            CreateMap<ShopPurchase, ShopPurchaseDTO>()
                .ForMember(dto => dto.Date, options => options.MapFrom(m => m.Date.ToShortDateString()))
                .ForMember(dto => dto.TotalPrice, options => options.MapFrom(m => m.TotalPrice));

            CreateMap<ShopPurchaseDTO, ShopPurchase>()
                .ForMember(m => m.Date, options => options.MapFrom(dto => DateTime.Parse(dto.Date)))
                .ForMember(m => m.TotalPrice, options => options.Ignore());
        }
    }
}
