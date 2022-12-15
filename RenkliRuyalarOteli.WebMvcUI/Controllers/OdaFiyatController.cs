using Microsoft.AspNetCore.Mvc;
using RenkliRuyalarOteli.BL.Abstract;

namespace RenkliRuyalarOteli.WebMvcUI.Controllers
{
    public class OdaFiyatController : Controller
    {
        private readonly IOdaFiyatManager odaFiyatManager;

        public OdaFiyatController(IOdaFiyatManager odaFiyatManager)
        {
            this.odaFiyatManager = odaFiyatManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await odaFiyatManager.FindAllAsnyc();
            return View(result);
        }
    }
}
