namespace ShopManager.Database.Model
{
    public class ShopProduct
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public virtual ShopProductCategory Category { get; set; }
        public virtual ICollection<ShopPurchase> Purchases { get; set; }
        public ShopProduct()
        {
            Purchases = new HashSet<ShopPurchase>();
        }
    }
}
