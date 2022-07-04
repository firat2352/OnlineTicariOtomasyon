using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            
            return View(_context.SatisHarekets.ToList());
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> urunler = (from urun in _context.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = urun.UrunAdi,
                                                Value = urun.UrunId.ToString(),
                                            }).ToList();

            List<SelectListItem> cariler = (from cari in _context.Caris.ToList()
                                            select new SelectListItem
                                            {
                                                Text = cari.CariAd+"" +cari.CariSoyad,
                                                Value = cari.CariId.ToString(),
                                            }).ToList();

            List<SelectListItem> personeller = (from personel in _context.Personels.ToList()
                                            select new SelectListItem
                                            {
                                                Text = personel.PersonelAd+ "" +personel.PersonelSoyad,
                                                Value = personel.PersonelId.ToString(),
                                            }).ToList();
            ViewBag.products = urunler;
            ViewBag.companies = cariler;
            ViewBag.personels = personeller;

            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket satis)
        {
            satis.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            _context.SatisHarekets.Add(satis);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}