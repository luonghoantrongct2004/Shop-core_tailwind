using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.DTOs
{
    public class TransactionPayDTO
    {
        public int TransactionId { get; set; }
        public int OrderId { get; set; }
        [Display(Name = "Phương thức thanh toán")]
        public string PaymentMethod { get; set; }
        [Display(Name = "Số tiền")]
        public decimal AmountMoney { get; set; }
        [Display(Name = "Ngày giao dịch")]
        public DateTime TransactionDate { get; set; }
        public string UserId { get; set; }
    }
}
