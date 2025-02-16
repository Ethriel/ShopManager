using ShopManager.Database.Model;
using ShopManager.Services;

namespace ShopManager.TestDbData.TestData
{
    public class TestPurchases
    {
        private readonly IEntityExtendedService<ShopPurchase> purchaseService;
        private readonly IEntityExtendedService<ShopProduct> productService;

        public TestPurchases(IEntityExtendedService<ShopPurchase> purchaseService, IEntityExtendedService<ShopProduct> productService)
        {
            this.purchaseService = purchaseService;
            this.productService = productService;
        }

        public void Create()
        {
            var product1 = productService.ReadById(1);
            var product2 = productService.ReadById(2);
            var product3 = productService.ReadById(3);
            var product4 = productService.ReadById(4);
            var product5 = productService.ReadById(5);

            var now = DateTime.Now;

            var purchase1 = new ShopPurchase
            {
                ClientId = 1,
                Date = now.AddDays(-1),
                Products = new HashSet<ShopProduct> { product1, product2 },
                Number = 1
            };

            purchaseService.Create(purchase1);

            var purchase2 = new ShopPurchase
            {
                ClientId = 1,
                Date = now.AddDays(-2),
                Products = new HashSet<ShopProduct> { product3, product5 },
                Number = 2
            };

            purchaseService.Create(purchase2);

            var purchase3 = new ShopPurchase
            {
                ClientId = 2,
                Date = now.AddDays(-1),
                Products = new HashSet<ShopProduct> { product4, product1 },
                Number = 3
            };

            purchaseService.Create(purchase3);

            var purchase4 = new ShopPurchase
            {
                ClientId = 2,
                Date = now.AddDays(-3),
                Products = new HashSet<ShopProduct> { product1, product3 },
                Number = 4
            };

            purchaseService.Create(purchase4);

            var purchase5 = new ShopPurchase
            {
                ClientId = 3,
                Date = now.AddDays(-1),
                Products = new HashSet<ShopProduct> { product4, product5 },
                Number = 5
            };

            purchaseService.Create(purchase5);

            var purchase6 = new ShopPurchase
            {
                ClientId = 3,
                Date = now.AddDays(-2),
                Products = new HashSet<ShopProduct> { product2, product3 },
                Number = 6
            };

            purchaseService.Create(purchase6);

            var purchase7 = new ShopPurchase
            {
                ClientId = 4,
                Date = now.AddDays(-2),
                Products = new HashSet<ShopProduct> { product1, product3 },
                Number = 7
            };

            purchaseService.Create(purchase7);

            var purchase8 = new ShopPurchase
            {
                ClientId = 4,
                Date = now.AddDays(-10),
                Products = new HashSet<ShopProduct> { product2, product5 },
                Number = 8
            };

            purchaseService.Create(purchase8);

            var purchase9 = new ShopPurchase
            {
                ClientId = 5,
                Date = now.AddDays(-8),
                Products = new HashSet<ShopProduct> { product3, product1 },
                Number = 9
            };

            purchaseService.Create(purchase9);

            var purchase10 = new ShopPurchase
            {
                ClientId = 5,
                Date = now.AddDays(-6),
                Products = new HashSet<ShopProduct> { product5, product1 },
                Number = 10
            };

            purchaseService.Create(purchase10);
        }
    }
}
