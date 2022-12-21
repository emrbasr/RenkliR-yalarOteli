using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RenkliRuyalarOteli.BL.Abstract;
using RenkliRuyalarOteli.Entities.Entites.Concrete;
using RenkliRuyalarOteli.Entities.Entities.Concrete;
using RenkliRuyalarOteli.WebMvcUI.Areas.Admin.Models.Kullanici;

namespace RenkliRuyalarOteli.WebMvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class KullaniciController : Controller
    {

        private readonly IKullaniciManager kullaniciManager;
        private readonly IRoleManager roleManager;

        public KullaniciController(IKullaniciManager kullaniciManager, IRoleManager roleManager)
        {
            this.roleManager = roleManager;
            this.kullaniciManager = kullaniciManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await kullaniciManager.FindAllIncludeAsync(null, p => p.Roller);
            return View(result.ToList());
        }
        public async Task<IActionResult> Kayit()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid Id)
        {
            var kullanici = kullaniciManager.FindAsync(p => p.Id == Id).Result;
            KullaniciUpdateDTO updateDto = new KullaniciUpdateDTO
            {
                Id = kullanici.Id,
                Adi = kullanici.Adi,
                Soyadi = kullanici.Soyadi,
                Email = kullanici.Email,
                Password = kullanici.Password,
                RePassword = kullanici.Password,
                DogumTarihi = kullanici.DogumTarihi,
                TcNo = kullanici.TcNo,
                Cinsiyet = kullanici.Cinsiyet,
                KullaniciAdi = kullanici.KullaniciAdi
            };
            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(KullaniciUpdateDTO updateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(updateDTO);
            }

            //Eger IFromFile Tipindeki prop bos degilse serverda upload klasorune kopyala
            // Ve Database'de ImageData alanina yazdir.
            var kul = kullaniciManager.FindAsync(p => p.Id == updateDTO.Id).Result;
            if (updateDTO.ImageFile != null)
            {
                var extent = Path.GetExtension(updateDTO.ImageFile.FileName);
                var randomName = ($"{Guid.NewGuid()}{extent}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Uploads", randomName);
                kul.ImageUrl = "Uploads\\" + randomName;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await updateDTO.ImageFile.CopyToAsync(stream);
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    //postedFile.CopyTo(ms);	
                    updateDTO.ImageFile.CopyTo(ms);
                    kul.ImageData = ms.ToArray();
                }
            }

            //UpdateDto Kullanici Tipine cevirmek gerekiyor


            kul.Adi = updateDTO.Adi;
            kul.Soyadi = updateDTO.Soyadi;
            kul.DogumTarihi = updateDTO.DogumTarihi;
            kul.Password = updateDTO.Password;
            kul.UpdateDate = DateTime.Now;

            var sonuc = await kullaniciManager.UpdateAsync(kul);
            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Kullanici");
            }
            else
            {
                ModelState.AddModelError("", "Bilinmeyen bir hata olustu. Lutfen Biraz sonra tekrar denbeyiniz");

                return View(updateDTO);
            }

        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var createDto = new KullaniciCreateDTO();

            @ViewBag.Roller = GetRoller();
            return View(createDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(KullaniciCreateDTO createDTO)
        {
            if (!ModelState.IsValid)
            {
                @ViewBag.Roller = GetRoller();
                return View(createDTO);
            }

            var kullanici = new Kullanici
            {
                Adi = createDTO.Adi,
                Soyadi = createDTO.Soyadi,
                Cinsiyet = true,
                DogumTarihi = createDTO.DogumTarihi,
                Email = createDTO.Email,
                TcNo = createDTO.TcNo,


            };

            if (createDTO.ImageFile != null)
            {
                var extent = Path.GetExtension(createDTO.ImageFile.FileName);
                var randomName = ($"{Guid.NewGuid()}{extent}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Uploads", randomName);
                kullanici.ImageUrl = "Uploads\\" + randomName;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await createDTO.ImageFile.CopyToAsync(stream);
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    //postedFile.CopyTo(ms);	
                    createDTO.ImageFile.CopyTo(ms);
                    kullanici.ImageData = ms.ToArray();
                }
            }


            var sonuc = await kullaniciManager.CreateAsync(kullanici);

            foreach (var item in createDTO.Roller)
            {


            }


            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Kullanici");
            }
            else
            {
                ModelState.AddModelError("", "Bilinmeyen bir hata olustu. Daha Sonra Tekrar Deneyiniz");
                @ViewBag.Roller = GetRoller();
                return View(createDTO);
            }





        }

        [NonAction]
        private List<SelectListItem> GetRoller()
        {
            var roller = roleManager.FindAllAsnyc(null).Result;

            List<SelectListItem> ListItemRols = new();
            foreach (Role role in roller)
            {
                ListItemRols.Add(new SelectListItem(role.RoleName, role.Id.ToString()));
            }
            return ListItemRols;
        }

    }
}
