namespace ShopManager.Database.Model
{
    public class ShopPurchase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public double TotalPrice { get => Products.Sum(p => p.Price); }
        public virtual ICollection<ShopProduct> Products { get; set; }
        public int ClientId { get; set; }
        public virtual ShopClient Client { get; set; }
        public ShopPurchase()
        {
            Products = new HashSet<ShopProduct>();
        }
    }
}
