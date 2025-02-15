namespace ShopManager.Services.Model.DTO
{
    public class ShopClientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string DateOfBirth { get; set; }
        public string RegistrationDate { get; set; }
        public ICollection<ShopPurchaseDTO> Purchases { get; set; }
    }
}
