using ShopDataAccess.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDataAccess.Entity.Order
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Display(Name = "Trạng thái đơn hàng")]
        public string Status { get; set; }
        [Display(Name = "Tổng tiền")]
        [Required]
        public decimal TotalAmount { get; set; }
        [Display(Name = "Địa chỉ giao hàng")]
        [Column(TypeName = "nvarchar")]
        public string ShippingAddress { get; set; }
        [Display(Name = "Phương thức thanh toán")]
        [Required]
        public string PaymentMethod { get; set; }
        [Display(Name = "Ngày mua hàng")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public DateTime UpdatedDate { get; set; }
        public virtual ShopUser User { get; set; }
    }
}
