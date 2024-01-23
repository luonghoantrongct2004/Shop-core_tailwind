using System.ComponentModel.DataAnnotations;

namespace ShopDataAccess.Entity.Blog
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} phải nhập.")]
        [Display(Name = "Tiêu đề")]
        public string TitleNew { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { get; set; }
    }
}
