namespace ShopService.Database.Model
{
    public class ShopClient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public virtual ICollection<ShopPurchase> Purchases { get; set; }
        public ShopClient()
        {
            Purchases = new HashSet<ShopPurchase>();
        }
    }
}
