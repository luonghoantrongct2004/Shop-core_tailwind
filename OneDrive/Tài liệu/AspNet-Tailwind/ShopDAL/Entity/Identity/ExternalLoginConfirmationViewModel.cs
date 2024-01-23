using System.ComponentModel.DataAnnotations;

namespace Shop.DAL.Entity.Identity
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Phải nhập {0}")]
        [EmailAddress(ErrorMessage = "Phải đúng định dạng email")]
        public string Email { get; set; }
    }
}
