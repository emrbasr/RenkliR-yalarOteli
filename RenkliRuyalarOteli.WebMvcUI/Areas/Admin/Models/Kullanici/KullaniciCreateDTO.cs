using System.ComponentModel.DataAnnotations;

namespace RenkliRuyalarOteli.WebMvcUI.Areas.Admin.Models.Kullanici
{
    public class KullaniciCreateDTO
    {
        public string? KullaniciAdi { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Zorunlu Alandir")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Şifre Zorunlu Alandir")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Şifre Zorunlu Alandir")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifre bilgileri uyumsuzdur")]
        public string RePassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "TcNo Zorunlu Alandir")]
        [MaxLength(11)]
        public string TcNo { get; set; }

        public string Adi { get; set; }
        public string Soyadi { get; set; }

        public bool Cinsiyet { get; set; }
        public DateTime DogumTarihi { get; set; }

        public IFormFile? ImageFile { get; set; }

        public List<string>? Roller { get; set; }

    }
}
