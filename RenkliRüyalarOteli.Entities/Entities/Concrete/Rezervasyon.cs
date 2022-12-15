using RenkliRüyalarOteli.Entities.Entities.Abstract;

namespace RenkliRuyalarOteli.Entities.Entites.Concrete
{
    public class Rezervasyon : BaseEntity
    {

        // Hangi Odaya Rezervasyon Yapildi        
        public Guid OdaId { get; set; }
        public Oda Oda { get; set; }

        // Odanin o tarihteki Fiyati nedir
        public Guid OdaFiyatId { get; set; }
        public OdaFiyat OdaFiyat { get; set; }

        //Odaya Giris ve Cikis Tarihleri
        public DateTime GirisTarihi { get; set; }
        public DateTime CikisTarihi { get; set; }

        public ICollection<RezervasyonDetay> RezervasyonDetaylari { get; set; }

        public Guid KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}