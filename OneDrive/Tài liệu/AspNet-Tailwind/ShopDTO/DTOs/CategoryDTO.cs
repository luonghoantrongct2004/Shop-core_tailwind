using System.ComponentModel.DataAnnotations;

namespace Shop.DTO.DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        [Display(Name = "Danh mục")]
        public string Title { get; set; }
        public int? ParentCategoryId { get; set; }
        public ICollection<CategoryDTO> CategoryChildren { get; set; }
        [Display(Name = "Danh mục cha")]
        public CategoryDTO ParentCategory { get; set; }

        [Display(Name = "Url hiện thị")]
        public string Slug { get; set; }
        [Display(Name = "Mô tả danh mục")]
        public string Description { get; set; }
        [Display(Name = "Tiêu đề danh mục")]
        public string MetaTitle { get; set; }
        [Display(Name = "Mô tả tiêu đề danh mục")]

        public string MetaDescription { get; set; }
    }
}
