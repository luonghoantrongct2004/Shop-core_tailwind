using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDataAccess.Entity.Product
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc.")]
        [Display(Name = "Tên sản phẩm")]
        [Column(TypeName = "nvarchar")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Phải tạo url")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} dài {1} đến {2}")]
        [RegularExpression(@"^[a-z0-9-]*$", ErrorMessage = "Chỉ dùng các ký tự [a-z0-9-]")]
        [Display(Name = "Url hiện thị")]
        public string Slug { get; set; }
        [Required(ErrorMessage = "{0} là bắt buộc.")]
        [Display(Name = "Mô tả sản phẩm")]
        [Column(TypeName = "nvarchar")]
        public string Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "{0} phải lớn hơn hoặc bằng 0.")]
        [Display(Name = "Giá sản phẩm")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Số lượng sản phẩm phải lớn hơn hoặc bằng 0.")]
        [Display(Name = "Số lượng sản phẩm")]
        public int Quantity { get; set; }

        public string Image { get; set; }
        public string Video { get; set; }

        [Required(ErrorMessage = "ID danh mục của sản phẩm là bắt buộc.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "ID thương hiệu của sản phẩm là bắt buộc.")]
        public int BrandId { get; set; }

        [MaxLength(100, ErrorMessage = "{0} không được vượt quá 100 ký tự.")]
        [Display(Name = "Tiêu đề sản phẩm")]
        public string MetaTitle { get; set; }
        [Display(Name = "Mô tả tiêu đề")]
        public string MetaDescription { get; set; }
        public ProductImage ProductImage { get; set; }
        public ProductVideo ProductVideo { get; set; }
    }
}
