using ShopManager.Database.Model;
using ShopManager.Services;

namespace ShopManager.TestDbData.TestData
{
    public class TestProducts
    {
        private readonly IEntityExtendedService<ShopProduct> productService;

        public TestProducts(IEntityExtendedService<ShopProduct> productService)
        {
            this.productService = productService;
        }

        public void Create()
        {
            var product1 = new ShopProduct
            {
                CategoryId = 1,
                Code = "DR-123",
                Name = "Цукор ваговий, 1кг",
                Price = 44.5
            };
            productService.Create(product1);

            var product2 = new ShopProduct
            {
                CategoryId = 2,
                Code = "FT-123",
                Name = "Ручка гелієва",
                Price = 15.25
            };
            productService.Create(product2);

            var product3 = new ShopProduct
            {
                CategoryId = 3,
                Code = "QE-123",
                Name = "Олія соняшникова, 1л",
                Price = 55.75
            };
            productService.Create(product3);

            var product4 = new ShopProduct
            {
                CategoryId = 4,
                Code = "DC-123",
                Name = "Блендер",
                Price = 2000
            };
            productService.Create(product4);

            var product5 = new ShopProduct
            {
                CategoryId = 5,
                Code = "ML-123",
                Name = "Куртка зимова",
                Price = 2500
            };
            productService.Create(product5);
        }
    }
}
