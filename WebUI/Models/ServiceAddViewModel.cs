using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class ServiceAddViewModel
    {
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı Adı boş geçilemez")]
        public string UserName { get; set; }

        [Display(Name = "Site Adı")]
        [Required(ErrorMessage = "Site Adı boş geçilemez")]
        public string SiteUrl { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre boş geçilemez")]
        public string Password { get; set; }

    }
}
