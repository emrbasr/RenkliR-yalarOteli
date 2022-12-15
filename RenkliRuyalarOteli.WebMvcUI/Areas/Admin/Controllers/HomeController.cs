using Microsoft.AspNetCore.Mvc;

namespace RenkliRuyalarOteli.WebMvcUI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
