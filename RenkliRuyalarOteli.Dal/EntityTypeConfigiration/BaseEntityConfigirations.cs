using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RenkliRüyalarOteli.Entities.Entities.Abstract;

namespace RenkliRuyalarOteli.DAL.EntityTypeConfigiration
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CreateDate).HasDefaultValue(new DateTime());



        }
    }
}
