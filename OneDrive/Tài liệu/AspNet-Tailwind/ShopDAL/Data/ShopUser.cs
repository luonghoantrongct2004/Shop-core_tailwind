using Microsoft.AspNetCore.Identity;
using Shop.DAL.Entity.Cart;
using ShopDataAccess.Entity.Order;
using ShopDataAccess.Entity.Pay;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public ICollection<TransactionPay> TransactionPays { get; set; }
        [ForeignKey("CartId")]
        public virtual Cart Carts { get; set; }
        public virtual Order Orders { get; set; }
    }
}
