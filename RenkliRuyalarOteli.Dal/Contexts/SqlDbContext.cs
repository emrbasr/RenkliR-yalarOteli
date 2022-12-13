using Microsoft.EntityFrameworkCore;
using RenkliRüyalarOteli.Entities.Entities.Concrete;
using System.Reflection;

namespace RenkliRüyalarOteli.Entities.Context
{
    public class SqlDbContext : DbContext
    {
        public DbSet<Kullanici> KullaniciLar { get; set; }
        public DbSet<Oda> Odalar { get; set; }
        public DbSet<OdaFiyat> OdaFiyatlari { get; set; }
        public DbSet<Rezervasyon> Rezervasyonlar { get; set; }
        public DbSet<RezervasyonDetay> RezervasyonDetay { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb;Database=RenkliRuyalarOteli;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

}
