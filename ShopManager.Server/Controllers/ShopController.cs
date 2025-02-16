using Microsoft.AspNetCore.Mvc;
using ShopManager.Database.Model;
using ShopManager.Server.Extensions;
using ShopManager.Services;
using ShopManager.Services.Abstraction;
using ShopManager.Services.Model.DTO;

namespace ShopManager.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopController : Controller
    {
        private readonly IShopService shopService;
        private readonly ILogger<ShopController> logger;
        private readonly IEntityExtendedService<ShopPurchase> purchaseService;
        private readonly IMapperService<ShopPurchase, ShopPurchaseDTO> purchaseMapperService;

        public ShopController(IShopService shopService,
            ILogger<ShopController> logger,
            IEntityExtendedService<ShopPurchase> purchaseService,
            IMapperService<ShopPurchase, ShopPurchaseDTO> purchaseMapperService)
        {
            this.shopService = shopService;
            this.logger = logger;
            this.purchaseService = purchaseService;
            this.purchaseMapperService = purchaseMapperService;
        }

        [HttpGet("birthday-people")]
        public async Task<IActionResult> GetBirthdayPeople()
        {
            var result = await shopService.GetBirthdayPeopleAsync();

            return this.ActionResultByApiResult(result, logger);
        }

        [HttpGet("birthday-people-by-date")]
        public async Task<IActionResult> GetBirthdayPeople([FromQuery] string dateString)
        {
            var result = await shopService.GetBirthdayPeopleAsync(dateString);

            return this.ActionResultByApiResult(result, logger);
        }

        [HttpGet("recent-clients")]
        public async Task<IActionResult> GetRecentClients([FromQuery] int days)
        {
            var result = await shopService.GetRecentClientsAsync(days);

            return this.ActionResultByApiResult(result, logger);
        }

        [HttpGet("popular-categories")]
        public async Task<IActionResult> GetClientPopularCategories([FromQuery] int clientId)
        {
            var result = await shopService.GetClientsPopularCategoriesAsync(clientId);

            return this.ActionResultByApiResult(result, logger);
        }
    }
}
