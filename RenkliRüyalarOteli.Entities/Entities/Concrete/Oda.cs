using RenkliRüyalarOteli.Entities.Entities.Abstract;

namespace RenkliRüyalarOteli.Entities.Entities.Concrete
{
    public class Oda : BaseEntity
    {
        public string OdaNo { get; set; }
        public byte KisiSayisi { get; set; }

        public bool Durum { get; set; } = true;


        public Guid KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }

        public ICollection<OdaFiyat> OdaFiyatlari { get; set; }
        public ICollection<Rezervasyon> Rezervasyonlari { get; set; }
    }
}
