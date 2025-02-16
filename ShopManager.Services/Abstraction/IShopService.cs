using ShopManager.Services.Utility.ApiResult;

namespace ShopManager.Services.Abstraction
{
    public interface IShopService
    {
        IApiResult GetBirthdayPeople();
        IApiResult GetBirthdayPeople(string dateString);
        Task<IApiResult> GetBirthdayPeopleAsync();
        Task<IApiResult> GetBirthdayPeopleAsync(string dateString);
        IApiResult GetRecentClients(int days);
        Task<IApiResult> GetRecentClientsAsync(int days);
        IApiResult GetClientsPopularCategories(int clientId);
        Task<IApiResult> GetClientsPopularCategoriesAsync(int clientId);
    }
}
