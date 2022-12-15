using RenkliRüyalarOteli.Entities.Entities.Abstract;

namespace RenkliRuyalarOteli.Entities.Entites.Concrete
{
    public class OdaFiyat : BaseEntity
    {
        public Guid OdaId { get; set; }
        public Oda Oda { get; set; }


        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }

        public float Fiyat { get; set; }


        public Guid KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }

        public ICollection<Rezervasyon> Rezervasyonlari { get; set; }
    }
}
