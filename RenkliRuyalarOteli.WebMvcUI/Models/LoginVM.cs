using System.ComponentModel.DataAnnotations;

namespace RenkliRuyalarOteli.WebMvcUI.Models
{
    public class LoginVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email girilmesi zorunludur...")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Şifre girilmesi zorunludur...")]
        public string Password { get; set; }

        public bool RememerMe { get; set; }

    }
}
