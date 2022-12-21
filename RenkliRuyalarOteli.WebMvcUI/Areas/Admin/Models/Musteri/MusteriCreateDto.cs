namespace RenkliRuyalarOteli.WebMvcUI.Areas.Admin.Models.Musteri
{
    public class MusteriCreateDto
    {
        public string Ad { get; set; }
        public string Soyadi { get; set; }
        public bool Cinsiyet { get; set; }
        public string? MusteriTcNo { get; set; }
        public string CepNo { get; set; }
    }
}
