using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDataAccess.Entity.Product
{
    public class Comment
    {
        [Key]
        public int ComnmentId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "Nội dung")]
        [Column(TypeName = "nvarchar")]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
