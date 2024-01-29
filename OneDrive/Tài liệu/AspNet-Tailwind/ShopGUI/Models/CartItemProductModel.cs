using Shop.DTO.DTOs;

namespace Shop.Web.Models
{
    public class CartItemProductModel
    {
        public int CartItemId { get; set; }
        public CartItemDTO CartItems { get; set; }

        public int ProductId { get; set; }
        public ProductDTO Products { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
    }
}
