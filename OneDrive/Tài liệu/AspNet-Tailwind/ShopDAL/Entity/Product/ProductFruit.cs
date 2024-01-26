using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shop.DAL.Entity.Product
{
    [Table("ProducFruit")]
    public class ProductFruit
    {
        [Key]
        public int FruitProductId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public string FruitType { get; set; }
        public string Ripeness { get; set; }
    }

}
