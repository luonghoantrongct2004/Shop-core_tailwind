using Microsoft.AspNetCore.Identity;
using ShopDataAccess.Entity.Pay;
using System.ComponentModel.DataAnnotations;

namespace ShopDataAccess.Models
{
    public class ShopUser:IdentityUser
    {
        [MaxLength(100)]
        public string FullName { set; get; }

        [MaxLength(255)]
        public string Address { set; get; }

        [DataType(DataType.Date)]
        public DateTime? Birthday { set; get; }
        public ICollection<TransactionPay> TransactionPay { get; set; }
    }
}
