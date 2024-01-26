using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Shop.DAL.Entity.Product
{
    [Table("ProductFashion")]
    public class ProductFashion
    {
            [Key]
            public int FashionProductId { get; set; }

            [ForeignKey("Product")]
            public int ProductId { get; set; }

            public string Size { get; set; }
    }
}
