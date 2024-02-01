using Shop.DTO.DTOs;
using System.ComponentModel.DataAnnotations;

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
        public List<string> Addresses { get; set; }

        [Display(Name = "Địa chỉ giao hàng")]
        public string SelectedAddress { get; set; }
    }
}
