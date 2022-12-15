using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RenkliRuyalarOteli.Entities.Entities.Concrete;

namespace RenkliRuyalarOteli.DAL.EntityTypeConfigiration
{
    public class RoleConfiguration : BaseEntityConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.RoleName)
                .IsRequired()
                .HasMaxLength(20);
            builder.HasIndex(p => p.RoleName).IsUnique();

            // builder.HasMany(p => p.Kullanicilar).WithMany(p => p.Roller);
        }
    }
}
