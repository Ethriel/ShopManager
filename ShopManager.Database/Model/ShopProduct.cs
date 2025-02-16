using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ShopManager.Database.Model
{
    public class ShopProduct
    {
        private readonly ILazyLoader lazyLoader;
        private ShopProductCategory category;
        private ICollection<ShopPurchase> purchases;
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public virtual ShopProductCategory Category
        {
            get => lazyLoader.Load(this, ref category);
            set => category = value;
        }
        public virtual ICollection<ShopPurchase> Purchases
        {
            get => lazyLoader.Load(this, ref purchases);
            set => purchases = value;
        }
        public ShopProduct()
        {
            Purchases = new HashSet<ShopPurchase>();
        }
        public ShopProduct(ILazyLoader lazyLoader) : this()
        {
            this.lazyLoader = lazyLoader;
        }
    }
}
