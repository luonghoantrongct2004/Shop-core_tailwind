using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDataAccess.Entity.Brand
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên thương hiệu")]
        [Column(TypeName = "nvarchar")]
        public string BrandName { get; set; }
        [Required(ErrorMessage = "{0} Phải tạo url")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} dài {1} đến {2}")]
        [RegularExpression(@"^[a-z0-9-]*$", ErrorMessage = "Chỉ dùng các ký tự [a-z0-9-]")]
        [Display(Name = "Url hiện thị")]
        public string Slug { get; set; }
        [Display(Name = "Mô tả thương hiệu")]
        [Column(TypeName = "nvarchar")]
        public string BrandDescription { get; set; }
        [Display(Name = "Tiêu đề thương hiệu")]
        public string MetaTitle { get; set; }
        [Display(Name = "Mô tả thương hiệu")]
        public string MetaDescription { get; set; }
    }
}
