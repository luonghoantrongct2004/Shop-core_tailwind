using ShopDataAccess.Entity.Product;

namespace Shop.DTO.DTOs
{
    public class CartItemDTO
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public int CartId { get; set; }
        public virtual CartDTO Cart { get; set; }
    }
}
