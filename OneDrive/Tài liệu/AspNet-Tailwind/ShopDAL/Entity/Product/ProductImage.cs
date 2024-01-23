using System.ComponentModel.DataAnnotations;

namespace ShopDataAccess.Entity.Product
{
    public class ProductImage
    {
        [Key]
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public string Image { get; set; }
        public Product Product { get; set; }

    }
}
