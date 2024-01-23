using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.DTOs
{
    public class ShippingDTO
    {
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
