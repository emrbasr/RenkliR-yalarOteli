namespace RenkliRuyalarOteli.WebMvcUI.Areas.Admin.Models.Oda
{
    public class OdaCreateDto
    {
        public string OdaNo { get; set; }
        public byte KisiSayisi { get; set; }

        public bool Durum { get; set; } = true;
    }
}
