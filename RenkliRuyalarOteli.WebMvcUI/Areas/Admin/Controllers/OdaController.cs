using Microsoft.AspNetCore.Mvc;
using RenkliRuyalarOteli.BL.Abstract;
using RenkliRuyalarOteli.Entities.Entites.Concrete;
using RenkliRuyalarOteli.WebMvcUI.Areas.Admin.Models.Oda;

namespace RenkliRuyalarOteli.WebMvcUI.Areas.Admin.Controllers
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
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var createDto = new OdaCreateDto();


            return View(createDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OdaCreateDto createDTO)
        {
            if (!ModelState.IsValid)
            {

                return View(createDTO);
            }

            var oda = new Oda
            {
                OdaNo = createDTO.OdaNo,
                KisiSayisi = createDTO.KisiSayisi,
                Durum = true,




            };




            var sonuc = await odaManager.CreateAsync(oda);




            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Oda");
            }
            else
            {
                ModelState.AddModelError("", "Bilinmeyen bir hata olustu. Daha Sonra Tekrar Deneyiniz");
                return View(createDTO);
            }
        }



    }
}

