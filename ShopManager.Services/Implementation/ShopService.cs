using FluentValidation.Results;
using ShopManager.Database.Model;
using ShopManager.Services.Abstraction;
using ShopManager.Services.Model.ApiResultModel;
using ShopManager.Services.Model.DTO;
using ShopManager.Services.Utility.ApiResult;
using ShopManager.Services.Validation;
using System.Linq.Expressions;

namespace ShopManager.Services.Implementation
{
    public class ShopService : IShopService
    {
        private readonly IGenericModelService<ShopClient, ShopClientDTO> clientService;
        private readonly IGenericModelService<ShopPurchase, ShopPurchaseDTO> purchaseService;
        private readonly BirthdayDateStringValidator birthdayDateValidator;
        private readonly PopularCategoriesCustomerIdValidator clientIdValidatior;
        private readonly RecentPurchasesDaysValidator recentPurchasesDaysValidator;

        public ShopService(IGenericModelService<ShopClient, ShopClientDTO> clientService,
                           IGenericModelService<ShopPurchase, ShopPurchaseDTO> purchaseService,
                           BirthdayDateStringValidator birthdayDateValidator,
                           PopularCategoriesCustomerIdValidator clientIdValidatior,
                           RecentPurchasesDaysValidator recentPurchasesDaysValidator)
        {
            this.clientService = clientService;
            this.purchaseService = purchaseService;
            this.birthdayDateValidator = birthdayDateValidator;
            this.clientIdValidatior = clientIdValidatior;
            this.recentPurchasesDaysValidator = recentPurchasesDaysValidator;
        }
        public IApiResult GetBirthdayPeople()
        {
            return ProcessBirthdayPeople(c => DateTime.Today.Day == c.DateOfBirth.Day && DateTime.Today.Month == c.DateOfBirth.Month);
        }

        public IApiResult GetBirthdayPeople(string dateString)
        {
            var validationResult = birthdayDateValidator.Validate(dateString);

            if (!validationResult.IsValid)
            {
                return ProcessValidationErrors(validationResult.Errors);
            }
            else
            {
                var date = DateOnly.Parse(dateString);

                return ProcessBirthdayPeople(c => date.Day == c.DateOfBirth.Day && date.Month == c.DateOfBirth.Month);
            }
        }

        public async Task<IApiResult> GetBirthdayPeopleAsync()
        {
            return await Task.FromResult(GetBirthdayPeople());
        }

        public async Task<IApiResult> GetBirthdayPeopleAsync(string dateString)
        {
            return await Task.FromResult(GetBirthdayPeople(dateString));
        }

        public IApiResult GetClientsPopularCategories(int clientId)
        {
            var validationResult = clientIdValidatior.Validate(clientId);

            if (!validationResult.IsValid)
            {
                return ProcessValidationErrors(validationResult.Errors);
            }
            else
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
        }

        public async Task<IApiResult> GetClientsPopularCategoriesAsync(int clientId)
        {
            return await Task.FromResult(GetClientsPopularCategories(clientId));
        }

        public IApiResult GetRecentClients(int days)
        {
            var validationResult = recentPurchasesDaysValidator.Validate(days);

            if (!validationResult.IsValid)
            {
                return ProcessValidationErrors(validationResult.Errors);
            }
            else
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
                                                            .DistinctBy(pd => pd.ClientFullName)
                                                            .ToArray();

                        return new ApiOkResult(data: purchasesData);
                    }
                }
                else
                {
                    return quaryResult;
                }
            }
        }

        public async Task<IApiResult> GetRecentClientsAsync(int days)
        {
            return await Task.FromResult(GetRecentClients(days));
        }

        private IApiResult ProcessBirthdayPeople(Expression<Func<ShopClient, bool>> expression)
        {
            var quaryResult = clientService.GetAllByCondition(expression);
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

        private IApiResult ProcessValidationErrors(IEnumerable<ValidationFailure> errors)
        {
            return new ApiErrorResult(errors: errors.Select(e => e.ErrorMessage));
        }
    }
}
