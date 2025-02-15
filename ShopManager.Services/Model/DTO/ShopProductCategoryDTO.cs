namespace ShopManager.Services.Model.DTO
{
    public class ShopProductCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ShopProductDTO> Products { get; set; }
    }
}
