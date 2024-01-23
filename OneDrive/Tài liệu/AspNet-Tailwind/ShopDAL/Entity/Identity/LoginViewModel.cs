using System.ComponentModel.DataAnnotations;

namespace Shop.DAL.Entity.Identity
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Địa chỉ email hoặc tên tài khoản")]
        public string UserNameOrEmail { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Ghi nhớ đăng nhập")]
        public bool RememberMe { get; set; }
    }
}
