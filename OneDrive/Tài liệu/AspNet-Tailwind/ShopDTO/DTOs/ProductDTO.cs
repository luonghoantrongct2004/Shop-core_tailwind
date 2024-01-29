using System.ComponentModel.DataAnnotations;

namespace Shop.DTO.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }

        [Display(Name = "Url hiện thị")]
        public string Slug { get; set; }
        [Display(Name = "Mô tả sản phẩm")]
        public string Description { get; set; }

        [Display(Name = "Giá sản phẩm")]
        public decimal Price { get; set; }

        [Display(Name = "Số lượng sản phẩm")]
        public int Quantity { get; set; }
        [Display(Name = "Số lượng đã bán")]
        public int SoldQuantity { get; set; }
        [Display(Name = "Kích thước")]
        public string Size { get; set; }
        [Display(Name = "Màu sắc")]
        public string Color { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }

        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        [Display(Name = "Tiêu đề sản phẩm")]
        public string MetaTitle { get; set; }
        [Display(Name = "Mô tả tiêu đề")]
        public string MetaDescription { get; set; }
        public ICollection<ProductImageDTO> ProductImageId { get; set; }
        public ProductVideoDTO ProductVideoId { get; set; }
        public CartItemDTO CartItems { get; set; }
    }
}
