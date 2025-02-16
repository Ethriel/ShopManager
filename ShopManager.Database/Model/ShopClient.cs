using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ShopManager.Database.Model
{
    public class ShopClient
    {
        private readonly ILazyLoader lazyLoader;
        private ICollection<ShopPurchase> purchases;
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateOnly RegistrationDate { get; set; }
        public virtual ICollection<ShopPurchase> Purchases 
        {
            get => lazyLoader.Load(this, ref purchases);
            set => purchases = value;
        }
        public ShopClient()
        {
            Purchases = new HashSet<ShopPurchase>();
        }
        public ShopClient(ILazyLoader lazyLoader) : this()
        {
            this.lazyLoader = lazyLoader;
        }

        public int GetAge()
        {
            var age = 0;
            var today = DateOnly.FromDateTime(DateTime.Today);

            age = today.Year - DateOfBirth.Year;
            if (age > 0)
            {
                age -= Convert.ToInt32(today < DateOfBirth.AddYears(age));
            }

            return age;
        }
    }
}
