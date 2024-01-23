using System.ComponentModel.DataAnnotations;

namespace ShopDataAccess.Entity.Pay
{
    public class TransactionPay
    {
        [Key]
        public int TransactionId { get; set; }
        public int OrderId { get; set; }
        [Display(Name = "Phương thức thanh toán")]
        [Required]
        public string PaymentMethod { get; set; }
        [Display(Name = "Số tiền")]
        public decimal AmountMoney { get; set; }
        [Display(Name = "Ngày giao dịch")]
        public DateTime TransactionDate { get; set; }
    }
}
