using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.DTOs
{
    public class BrandDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên thương hiệu")]
        public string BrandName { get; set; }
        [Display(Name = "Url hiện thị")]
        public string Slug { get; set; }
        [Display(Name = "Mô tả thương hiệu")]
        public string BrandDescription { get; set; }
        [Display(Name = "Tiêu đề thương hiệu")]
        public string MetaTitle { get; set; }
        [Display(Name = "Mô tả thương hiệu")]
        public string MetaDescription { get; set; }
    }
}
