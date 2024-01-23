using System.ComponentModel.DataAnnotations;

namespace ShopDataAccess.Entity.Shipping
{
    public class Shipping
    {
        [Key]
        public int ShippingId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Display(Name = "Phương thức vận chuyển")]
        public string ShippingMethod { get; set; }
        [Display(Name = "Phí vận chuyển")]
        public decimal ShippingCost { get; set; }
        [Display(Name = "Địa chỉ giao hàng")]
        public string ShippingAddress { get; set; }
    }
}
