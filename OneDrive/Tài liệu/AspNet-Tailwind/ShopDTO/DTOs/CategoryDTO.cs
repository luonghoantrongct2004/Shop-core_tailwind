using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        [Display(Name = "Danh mục")]
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
        public int? ParentCategory { get; set; }

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
