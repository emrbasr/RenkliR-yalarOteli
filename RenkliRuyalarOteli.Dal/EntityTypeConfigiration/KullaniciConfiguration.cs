using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RenkliRuyalarOteli.Entities.Entites.Concrete;

namespace RenkliRuyalarOteli.DAL.EntityTypeConfigiration
{
    public class KullaniciConfiguration : BaseEntityConfiguration<Kullanici>
    {
        public override void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.TcNo).HasMaxLength(11);
            builder.Property(p => p.Email).HasMaxLength(50);
            builder.Property(p => p.Adi).HasMaxLength(20);
            builder.Property(p => p.Soyadi).HasMaxLength(20);
            builder.Property(p => p.KullaniciAdi).HasMaxLength(20);

            builder.HasIndex(p => p.KullaniciAdi).IsUnique();
            builder.HasIndex(p => p.TcNo).IsUnique();
            builder.HasIndex(p => p.Email).IsUnique();

        }
    }
}
