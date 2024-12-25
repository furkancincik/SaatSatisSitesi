using System.ComponentModel.DataAnnotations;

namespace SaatSatisSitesi.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email gerekli.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifre gerekli.")]
        public string Password { get; set; } = string.Empty;
    }
}
