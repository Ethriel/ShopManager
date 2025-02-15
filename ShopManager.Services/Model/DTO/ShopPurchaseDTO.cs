namespace ShopManager.Services.Model.DTO
{
    public class ShopPurchaseDTO
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int Number { get; set; }
        public double TotalPrice { get; set; }
        public ICollection<ShopProductDTO> Products { get; set; }
        public int ClientId { get; set; }
        public ShopClientDTO Client { get; set; }
    }
}
