using RenkliRuyalarOteli.Entities.Entites.Concrete;
using RenkliRüyalarOteli.Entities.Entities.Abstract;

namespace RenkliRuyalarOteli.Entities.Entities.Concrete
{
    public class Role : BaseEntity
    {
        public string? RoleName { get; set; }

        public ICollection<Kullanici>? Kullanicilar { get; set; }

    }
}
