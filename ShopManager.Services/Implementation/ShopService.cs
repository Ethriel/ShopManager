using ShopManager.Database.Model;
using ShopManager.Services.Abstraction;
using ShopManager.Services.Model.ApiResultModel;
using ShopManager.Services.Model.DTO;
using ShopManager.Services.Utility.ApiResult;

namespace ShopManager.Services.Implementation
{
    public class ShopService : IShopService
    {
        private readonly IGenericModelService<ShopClient, ShopClientDTO> clientService;
        private readonly IGenericModelService<ShopPurchase, ShopPurchaseDTO> purchaseService;

        public ShopService(IGenericModelService<ShopClient, ShopClientDTO> clientService, IGenericModelService<ShopPurchase, ShopPurchaseDTO> purchaseService)
        {
            this.clientService = clientService;
            this.purchaseService = purchaseService;
        }
        public IApiResult GetBirthdayPeople()
        {
            var today = DateTime.Today;
            var quaryResult = clientService.GetAllByCondition(c => today.Day == c.DateOfBirth.Day && today.Month == c.DateOfBirth.Month);

            if (quaryResult is IApiOkResult okResult && okResult.Data is IEnumerable<ShopClientDTO> clients)
            {
                var birthdayPeople = clients.Select(c => new ApiResultPerson { ClientId = c.Id, ClientFullName = c.FullName })
                                            .ToArray();

                return new ApiOkResult(data: birthdayPeople);
            }
            else
            {
                return quaryResult;
            }
        }

        public async Task<IApiResult> GetBirthdayPeopleAsync()
        {
            return await Task.FromResult(GetBirthdayPeople());
        }

        public IApiResult GetClientsPopularCategories(object clientId)
        {
            var quaryResult = clientService.GetById(clientId);

            if (quaryResult is IApiOkResult okResult && okResult.Data is ShopClientDTO client)
            {
                var clientCategories = client.Purchases.SelectMany(purchase => purchase.Products)
                                                        .GroupBy(product => product.Category)
                                                        .Select(group => new ApiResultCategory { CategoryName = group.Key.Name, PurchasedQuantity = group.Count() })
                                                        .ToArray();

                return new ApiOkResult(data: clientCategories);
            }
            else
            {
                return quaryResult;
            }
        }

        public async Task<IApiResult> GetClientsPopularCategoriesAsync(object clientId)
        {
            return await Task.FromResult(GetClientsPopularCategories(clientId));
        }

        public IApiResult GetLastClients(int days)
        {
            var today = DateTime.Today;
            var targetDate = today.AddDays(-days).Date;

            var quaryResult = purchaseService.GetAllByCondition(purchase => purchase.Date.Date >= targetDate && purchase.Date.Date <= today);
            if (quaryResult is IApiOkResult okResult && okResult.Data is IEnumerable<ShopPurchaseDTO> matchedPurchases)
            {
                if (!matchedPurchases.Any())
                {
                    var errorMessage = $"No purchases within the last {days} days found";
                    return new ApiErrorResult(ApiResultStatus.NotFound, loggerErrorMessage: errorMessage, errors: [errorMessage]);
                }
                else
                {
                    var purchasesData = matchedPurchases.GroupBy(purchase => purchase.Client)
                                                        .Select(group => new ApiResultPurchase
                                                        {
                                                            ClientFullName = group.Key.FullName,
                                                            LastPurchaseDate = group.Max(p => DateTime.Parse(p.Date)).ToShortDateString()
                                                        })
                                                        .ToArray();

                    return new ApiOkResult(data: purchasesData);
                }
            }
            else
            {
                return quaryResult;
            }
        }

        public async Task<IApiResult> GetLastClientsAsync(int days)
        {
            return await Task.FromResult(GetLastClients(days));
        }
    }
}
