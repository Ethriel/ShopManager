using ShopManager.Services.Abstraction;
using ShopManager.Services.Implementation;
using ShopManager.Services;
using ShopManager.TestDbData.TestData;
using ShopManager.Services.Validation;

namespace ShopManager.Server.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IEntityService<>), typeof(EntityService<>))
                   .AddScoped(typeof(IEntityExtendedService<>), typeof(EntityExtendedService<>))
                   .AddScoped(typeof(IMapperService<,>), typeof(MapperService<,>))
                   .AddScoped(typeof(IGenericModelService<,>), typeof(GenericModelService<,>))
                   .AddScoped<IShopService, ShopService>();
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            return services.AddScoped<BirthdayDateStringValidator>()
                           .AddScoped<RecentPurchasesDaysValidator>()
                           .AddScoped<PopularCategoriesCustomerIdValidator>();
        }

        public static IServiceCollection AddTestDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            var createTestData = configuration.GetValue<bool>("CreateTestData");

            if (createTestData)
            {
                // Test data services
               services.AddScoped<TestCategories>()
                       .AddScoped<TestProducts>()
                       .AddScoped<TestClients>()
                       .AddScoped<TestPurchases>()
                       .AddScoped<TestDataService>();
            }

            return services;
        }
    }
}
