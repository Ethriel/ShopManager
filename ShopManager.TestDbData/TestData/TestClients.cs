using ShopManager.Database.Model;
using ShopManager.Services;

namespace ShopManager.TestDbData.TestData
{
    public class TestClients
    {
        private readonly IEntityExtendedService<ShopClient> clientService;

        public TestClients(IEntityExtendedService<ShopClient> clientService)
        {
            this.clientService = clientService;
        }
        public void Create()
        {
            var now = DateTime.Now;

            var client1 = new ShopClient()
            {
                DateOfBirth = DateOnly.FromDateTime(now.AddYears(-35).AddMonths(-1).AddDays(-2)),
                FullName = "Кондратюк Юлія Сергіївна",
                RegistrationDate = DateOnly.FromDateTime(now.AddMonths(-2).AddDays(-10))
            };
            clientService.Create(client1);

            var client2 = new ShopClient()
            {
                DateOfBirth = DateOnly.FromDateTime(now.AddYears(-30)),
                FullName = "Микулин Арсен Петрович",
                RegistrationDate = DateOnly.FromDateTime(now.AddMonths(-1).AddDays(-10))
            };
            clientService.Create(client2);

            var client3 = new ShopClient()
            {
                DateOfBirth = DateOnly.FromDateTime(now.AddYears(-29)),
                FullName = "Шевченко Марія Василівна",
                RegistrationDate = DateOnly.FromDateTime(now.AddDays(-2))
            };
            clientService.Create(client3);

            var client4 = new ShopClient()
            {
                DateOfBirth = DateOnly.FromDateTime(now.AddYears(-31).AddMonths(1).AddDays(-3)),
                FullName = "Ткаченко Василь Володимирович",
                RegistrationDate = DateOnly.FromDateTime(now.AddMonths(-3).AddDays(3))
            };
            clientService.Create(client4);

            var client5 = new ShopClient()
            {
                DateOfBirth = DateOnly.FromDateTime(now.AddYears(-19).AddMonths(-2).AddDays(2)),
                FullName = "Мельник Ірина Валеріївна",
                RegistrationDate = DateOnly.FromDateTime(now.AddDays(-1))
            };
            clientService.Create(client4);
        }
    }
}
