using Microsoft.AspNetCore.Mvc;
using RenkliRuyalarOteli.BL.Abstract;

namespace RenkliRuyalarOteli.WebMvcUI.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly IKullaniciManager kullaniciManager;

        public KullaniciController(IKullaniciManager kullaniciManager)
        {
            this.kullaniciManager = kullaniciManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await kullaniciManager.FindAllAsnyc();
            return View(result);
        }
        public async Task<IActionResult> Kayit()
        {
            return View();
        }
    }
}
