﻿using System.ComponentModel.DataAnnotations;

namespace Shop.DAL.Entity.Identity
{
    public class VerifyAuthenticatorCodeViewModel
    {
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "Nhập mã đã lưu")]
        public string Code { get; set; }

        public string ReturnUrl { get; set; }

        [Display(Name = "Nhớ thông tin trình duyệt này?")]
        public bool RememberBrowser { get; set; }

        [Display(Name = "Nhớ thông tin đăng nhập?")]
        public bool RememberMe { get; set; }
    }
}
