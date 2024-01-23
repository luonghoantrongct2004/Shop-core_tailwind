using System.ComponentModel.DataAnnotations;

namespace ShopDataAccess.Entity.Product
{
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
