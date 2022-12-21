using RenkliRuyalarOteli.BL.Abstract;
using RenkliRuyalarOteli.BL.Concrete;

namespace RenkliRuyalarOteli.WebMvcUI.Extentions
{
    public static class MyExtentions
    {
        public static IServiceCollection AddRenkliRuyalarManager(this IServiceCollection services)
        {
            services.AddScoped<IKullaniciManager, KullaniciManager>();
            services.AddScoped<IMusteriManager, MusteriManager>();
            services.AddScoped<IOdaManager, OdaManager>();
            services.AddScoped<IOdaFiyatManager, OdaFiyatManager>();
            services.AddScoped<IRezervasyonManager, RezervasyonManager>();
            services.AddScoped<IRezervasyonDetayManager, RezervasyonDetayManager>();
            services.AddScoped<IRoleManager, RoleManager>();

            return services;
        }

    }
}
