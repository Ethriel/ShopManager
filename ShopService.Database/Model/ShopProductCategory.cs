namespace ShopService.Database.Model
{
    public class ShopProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ShopProduct> Products { get; set; }
        public ShopProductCategory()
        {
            Products = new HashSet<ShopProduct>();
        }
    }
}
