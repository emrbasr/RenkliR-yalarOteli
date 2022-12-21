using RenkliRuyalarOteli.DAL.Abstract;
using RenkliRuyalarOteli.Entities.Entites.Concrete;

namespace RenkliRuyalarOteli.DAL.Concrete
{
    public class KullaniciDal : RepostoryBase<Kullanici>, IKullaniciDal
    {
        public override Task<int> CreateAsync(Kullanici entity)
        {
            return base.CreateAsync(entity);
        }
    }
}
