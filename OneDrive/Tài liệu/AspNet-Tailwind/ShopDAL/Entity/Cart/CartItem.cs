using ShopDataAccess.Entity.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entity.Cart
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        [ForeignKey("CartId")]
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
