using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ShopManager.Database.Model
{
    public class ShopPurchase
    {
        private readonly ILazyLoader lazyLoader;
        private ShopClient client;
        private ICollection<ShopProduct> products;
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public double TotalPrice { get => Products.Sum(p => p.Price); }
        public virtual ICollection<ShopProduct> Products
        {
            get => lazyLoader.Load(this, ref products);
            set => products = value;
        }
        public int ClientId { get; set; }
        public virtual ShopClient Client
        {
            get => lazyLoader.Load(this, ref client);
            set => client = value;
        }
        public ShopPurchase()
        {
            Products = new HashSet<ShopProduct>();
        }
        public ShopPurchase(ILazyLoader lazyLoader) : this()
        {
            this.lazyLoader = lazyLoader;
        }
        public double GetTotalPrice()
        {
            return Products.Sum(p => p.Price);
        }
    }
}
