using ShopDataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entity.Cart
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice {get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public virtual ShopUser User { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
