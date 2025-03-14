﻿namespace ShopManager.Services.Model.DTO
{
    public class ShopProductDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public ShopProductCategoryDTO Category { get; set; }
        public ICollection<ShopPurchaseDTO> Purchases { get; set; }
    }
}
