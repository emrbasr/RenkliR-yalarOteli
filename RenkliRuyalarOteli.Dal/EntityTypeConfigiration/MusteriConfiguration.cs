using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RenkliRuyalarOteli.Entities.Entites.Concrete;

namespace RenkliRuyalarOteli.DAL.EntityTypeConfigiration
{
    public class MusteriConfiguration : BaseEntityConfiguration<Musteri>
    {
        public override void Configure(EntityTypeBuilder<Musteri> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.MusteriTcNo).HasMaxLength(11);
            builder.Property(p => p.Ad).HasMaxLength(30);
            builder.Property(p => p.Soyadi).HasMaxLength(30);
            builder.Property(p => p.CepNo).HasMaxLength(20);

            builder.HasOne(p => p.Kullanici)
                .WithMany(p => p.Musteriler)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
