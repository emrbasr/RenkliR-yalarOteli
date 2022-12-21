using Microsoft.AspNetCore.Mvc;
using RenkliRuyalarOteli.BL.Abstract;

namespace RenkliRuyalarOteli.WebMvcUI.Areas.Admin.Controllers
{
    public class RezervasyonDetayController : Controller
    {
        private readonly IRezervasyonDetayManager rezarvasyonDetayManager;

        public RezervasyonDetayController(IRezervasyonDetayManager rezarvasyonDetayManager)
        {
            this.rezarvasyonDetayManager = rezarvasyonDetayManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await rezarvasyonDetayManager.FindAllAsnyc();
            return View(result);
        }
    }
}
