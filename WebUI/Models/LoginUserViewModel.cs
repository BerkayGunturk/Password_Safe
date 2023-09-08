using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class LoginUserViewModel
    {
        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Lütfen Mail giriniz")]
        public string Email { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifre giriniz")]
        public string Password { get; set; }
    }
}
