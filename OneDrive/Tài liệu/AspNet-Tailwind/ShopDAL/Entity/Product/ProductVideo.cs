using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDataAccess.Entity.Product
{
    [Table("ProductVideo")]
    public class ProductVideo
    {
        [Key]
        public int VideoId { get; set; }
        public int ProductId { get; set; }
        public string VideoUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Product Product { get; set; }

    }
}
