using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RenkliRüyalarOteli.Entities.Entities.Concrete;

namespace RenkliRuyalarOteli.DAL.EntityTypeConfigiration
{
    public class OdaFiyatConfiguration : BaseEntityConfiguration<OdaFiyat>
    {
        public override void Configure(EntityTypeBuilder<OdaFiyat> builder)
        {
            base.Configure(builder);
            builder.HasOne(p => p.Kullanici)
              .WithMany(p => p.OdaFiyatlari)
              .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

        }

    }
}
