using AutoMapper;
using ShopManager.Database.Model;
using ShopManager.Services.Model.DTO;

namespace ShopManager.Services.Model.Mapper.CustomResolvers
{
    public class PurchaseTotalPriceMapResolver : IValueResolver<ShopPurchase, ShopPurchaseDTO, double>
    {
        public double Resolve(ShopPurchase source, ShopPurchaseDTO destination, double destMember, ResolutionContext context)
        {
            return source.GetTotalPrice();
        }
    }
}
