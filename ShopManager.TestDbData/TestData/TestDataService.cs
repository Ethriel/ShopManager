namespace ShopManager.TestDbData.TestData
{
    public class TestDataService
    {
        private readonly TestClients testClients;
        private readonly TestProducts testProducts;
        private readonly TestCategories testCategories;
        private readonly TestPurchases testPurchases;

        public TestDataService(TestClients testClients, TestProducts testProducts, TestCategories testCategories, TestPurchases testPurchases)
        {
            this.testClients = testClients;
            this.testProducts = testProducts;
            this.testCategories = testCategories;
            this.testPurchases = testPurchases;
        }

        public void CreateTestData()
        {
            testCategories.Create();
            testClients.Create();
            testProducts.Create();
            testPurchases.Create();
        }
    }
}
