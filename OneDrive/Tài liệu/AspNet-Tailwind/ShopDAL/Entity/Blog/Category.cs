using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDataAccess.Entity.Blog
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Phải nhập {0}.")]
        [StringLength(50)]
        [Display(Name = "Danh mục")]
        [Column(TypeName = "nvarchar")]
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
        [ForeignKey("ParentCategoryId")]
        public virtual Category ParentCategory { get; set; }

        [Required(ErrorMessage = "Phải tạo url")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} dài {1} đến {2}")]
        [RegularExpression(@"^[a-z0-9-]*$", ErrorMessage = "Chỉ dùng các ký tự [a-z0-9-]")]
        [Display(Name = "Url hiện thị")]
        public string Slug { get; set; }
        [Display(Name = "Mô tả danh mục")]
        [Column(TypeName = "nvarchar")]
        public string Description { get; set; }

        [MaxLength(100, ErrorMessage = "{0} trang danh mục không được vượt quá 100 ký tự.")]
        [Display(Name = "Tiêu đề danh mục")]
        public string MetaTitle { get; set; }
        [Display(Name = "Mô tả tiêu đề danh mục")]

        public string MetaDescription { get; set; }
    }
}
