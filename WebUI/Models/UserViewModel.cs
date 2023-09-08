using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
	public class UserViewModel
	{

        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Lütfen Kullanıcı Adı giriniz")]
        public string UserName { get; set; }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Lütfen Ad giriniz")]
        public string FirstName { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Lütfen Soyadı giriniz")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Lütfen Mail giriniz")]
        [EmailAddress(ErrorMessage ="E mail hatalı")]
        public string Email { get; set; }

        [Display(Name = "Şifre ")]
        [Required(ErrorMessage = "Lütfen Şifre giriniz")]
        public string Password { get; set; }
        
    }
}
