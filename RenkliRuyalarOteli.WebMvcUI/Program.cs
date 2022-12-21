using Microsoft.AspNetCore.Authentication.Cookies;
using RenkliRuyalarOteli.WebMvcUI.Extentions;

namespace RenkliRuyalarOteli.WebMvcUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRenkliRuyalarManager();

            #region Cookie Base Authentication Ayarlarý
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                              .AddCookie(p =>
                              {
                                  p.LoginPath = "/Login/Giris";
                                  p.LogoutPath = "/Login/LogOut";
                                  p.Cookie.Name = "RenkliRuyalarOTel";
                                  p.ExpireTimeSpan = TimeSpan.FromMinutes(30);   // Atýlan cookie ne kadar süre geçerli olacaksa belirttik.
                              });
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}