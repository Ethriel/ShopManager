using Microsoft.EntityFrameworkCore;
using ShopManager.Database;
using ShopManager.TestDbData.TestData;

namespace ShopManager.Server.Extensions
{
    public static class WebAppExtensions
    {
        public static WebApplication? UseTestDataServices(this WebApplication app)
        {
            var isFirstRun = app.Configuration.GetValue<bool>("IsFirstRun");
            var createTestData = app.Configuration.GetValue<bool>("CreateTestData");

            if (isFirstRun)
            {
                using (var dbContextScope = app.Services.CreateScope())
                {
                    var appDbContext = dbContextScope.ServiceProvider.GetService<ShopDbContext>();
                    if (appDbContext != null && !appDbContext.Database.CanConnect())
                    {
                        appDbContext?.Database.Migrate();
                    }
                }
            }

            if (createTestData)
            {
                using (var testDataScope = app.Services.CreateScope())
                {
                    var testDataService = testDataScope.ServiceProvider.GetService<TestDataService>();
                    testDataService?.CreateTestData();
                }
            }

            return app;
        }
    }
}
