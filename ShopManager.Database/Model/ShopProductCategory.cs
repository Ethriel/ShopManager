using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ShopManager.Database.Model
{
    public class ShopProductCategory
    {
        private ICollection<ShopProduct> products;
        private readonly ILazyLoader lazyLoader;

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ShopProduct> Products
        {
            get => lazyLoader.Load(this, ref products);
            set => products = value;
        }
        public ShopProductCategory()
        {
            Products = new HashSet<ShopProduct>();
        }
        public ShopProductCategory(ILazyLoader lazyLoader) : this()
        {
            this.lazyLoader = lazyLoader;
        }
    }
}
