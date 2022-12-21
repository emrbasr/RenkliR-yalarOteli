using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RenkliRuyalarOteli.BL.Abstract;
using RenkliRuyalarOteli.Entities.Entites.Concrete;
using RenkliRuyalarOteli.WebMvcUI.Areas.Admin.Models.Musteri;
using System.Security.Claims;

namespace RenkliRuyalarOteli.WebMvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MusteriController : Controller
    {
        private readonly IMusteriManager musteriManager;

        public MusteriController(IMusteriManager musteriManager)
        {
            this.musteriManager = musteriManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await musteriManager.FindAllAsnyc();
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            Musteri musteri = new();

            var createDto = new MusteriCreateDto();


            return View(createDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MusteriCreateDto createDTO)
        {
            if (!ModelState.IsValid)
            {

                return View(createDTO);
            }
            var kullaniciId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var musteri = new Musteri

            {
                Ad = createDTO.Ad,
                Soyadi = createDTO.Soyadi,
                MusteriTcNo = createDTO.MusteriTcNo,
                Cinsiyet = true,
                CepNo = createDTO.CepNo,
                KullaniciId = Guid.Parse(kullaniciId),

            };




            var sonuc = await musteriManager.CreateAsync(musteri);




            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Musteri");
            }
            else
            {
                ModelState.AddModelError("", "Bilinmeyen bir hata olustu. Daha Sonra Tekrar Deneyiniz");

                return View(createDTO);
            }

        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid Id)
        {
            var musteri = musteriManager.FindAsync(p => p.Id == Id).Result;
            MusteriUpdateDto updateDto = new MusteriUpdateDto
            {

                Ad = musteri.Ad,
                Soyadi = musteri.Soyadi,
                MusteriTcNo = musteri.MusteriTcNo,
                Cinsiyet = musteri.Cinsiyet,

            };
            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(MusteriUpdateDto updateDTO)
        {
            var musteri = musteriManager.FindAsync(p => p.MusteriTcNo == updateDTO.MusteriTcNo).Result;
            if (!ModelState.IsValid)
            {
                return View(updateDTO);
            }

            //Eger IFromFile Tipindeki prop bos degilse serverda upload klasorune kopyala
            // Ve Database'de ImageData alanina yazdir.

            musteri.Ad = updateDTO.Ad;
            musteri.Soyadi = updateDTO.Soyadi;
            musteri.MusteriTcNo = updateDTO.MusteriTcNo;
            musteri.Cinsiyet = updateDTO.Cinsiyet;


            var sonuc = await musteriManager.CreateAsync(musteri);
            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Musteri");
            }
            else
            {
                ModelState.AddModelError("", "Bilinmeyen bir hata olustu. Lutfen Biraz sonra tekrar denbeyiniz");

                return View(updateDTO);
            }

        }



    }
}
