using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        [Display(Name = "Trạng thái đơn hàng")]
        public string Status { get; set; }
        [Display(Name = "Tổng tiền")]
        public decimal TotalAmount { get; set; }
        [Display(Name = "Địa chỉ giao hàng")]
        public string ShippingAddress { get; set; }
        [Display(Name = "Phương thức thanh toán")]
        public string PaymentMethod { get; set; }
        [Display(Name = "Ngày mua hàng")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public DateTime UpdatedDate { get; set; }
        int User { get; set; }
    }
}
