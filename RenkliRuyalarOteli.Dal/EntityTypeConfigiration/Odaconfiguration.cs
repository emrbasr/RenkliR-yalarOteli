using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RenkliRuyalarOteli.Entities.Entites.Concrete;

namespace RenkliRuyalarOteli.DAL.EntityTypeConfigiration
{
    public class Odaconfiguration : BaseEntityConfiguration<Oda>
    {
        public override void Configure(EntityTypeBuilder<Oda> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.OdaNo).HasMaxLength(50);
            builder.HasOne(p => p.Kullanici)
                .WithMany(p => p.Odalar)
                .HasForeignKey(p => p.KullaniciId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
