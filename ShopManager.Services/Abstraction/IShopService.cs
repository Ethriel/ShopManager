using ShopManager.Services.Utility.ApiResult;

namespace ShopManager.Services.Abstraction
{
    public interface IShopService
    {
        IApiResult GetBirthdayPeople();
        Task<IApiResult> GetBirthdayPeopleAsync();
        IApiResult GetLastClients(int days);
        Task<IApiResult> GetLastClientsAsync(int days);
        IApiResult GetClientsPopularCategories(object clientId);
        Task<IApiResult> GetClientsPopularCategoriesAsync(object clientId);
    }
}
