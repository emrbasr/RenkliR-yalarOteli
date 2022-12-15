using Microsoft.AspNetCore.Mvc;
using RenkliRuyalarOteli.BL.Abstract;

namespace RenkliRuyalarOteli.WebMvcUI.Controllers
{
    public class OdaController : Controller
    {
        private readonly IOdaManager odaManager;

        public OdaController(IOdaManager odaManager)
        {
            this.odaManager = odaManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await odaManager.FindAllAsnyc();
            return View(result);
        }
    }
}
