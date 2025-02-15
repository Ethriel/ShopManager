using ShopManager.Database.Model;
using ShopManager.Services;

namespace ShopManager.TestDbData.TestData
{
    public class TestCategories
    {
        private readonly IEntityExtendedService<ShopProductCategory> categoryService;

        public TestCategories(IEntityExtendedService<ShopProductCategory> categoryService)
        {
            this.categoryService = categoryService;
        }

        public void Create()
        {
            var cagory1 = new ShopProductCategory() { Name = "Бакалія" };
            categoryService.Create(cagory1);
            var cagory2 = new ShopProductCategory() { Name = "Канцелярські товари" };
            categoryService.Create(cagory2);
            var cagory3 = new ShopProductCategory() { Name = "Рослинні олії" };
            categoryService.Create(cagory3);
            var cagory4 = new ShopProductCategory() { Name = "Побутова техніка" };
            categoryService.Create(cagory4);
            var cagory5 = new ShopProductCategory() { Name = "Верхній одяг" };
            categoryService.Create(cagory5);
        }
    }
}
