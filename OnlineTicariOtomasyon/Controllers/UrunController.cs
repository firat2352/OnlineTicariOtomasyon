using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            return View(_context.Uruns.ToList());
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> liste=(from ktgr in _context.Kategories.ToList()
             select new SelectListItem
             {
                 Text = ktgr.KategoriAd,
                 Value = ktgr.KategoriId.ToString()
             }).ToList();

            ViewBag.DropDownListe = liste;
            return View();
        }


        [HttpPost]
        public ActionResult UrunEkle(Urun urun)
        {
            _context.Uruns.Add(urun);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            Urun urun=_context.Uruns.Find(id);
            _context.Uruns.Remove(urun);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> liste = (from ktgr in _context.Kategories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = ktgr.KategoriAd,
                                              Value = ktgr.KategoriId.ToString()
                                          }).ToList();

            ViewBag.DropDownListe = liste;
            var urun=_context.Uruns.Find(id);

            return View(urun);
        }

        public ActionResult UrunGuncelle(Urun urun)
        {
            var urn=_context.Uruns.Find(urun.UrunId);
            urn.UrunAdi = urun.UrunAdi;
            urn.AlisFiyat = urun.AlisFiyat;
            urn.Durum = urun.Durum;
            urn.KategoriId = urun.KategoriId;
            urn.Marka = urun.Marka;
            urn.SatisFiyat = urun.SatisFiyat;
            urn.Stok = urun.Stok;
            urn.UrunGorsel = urun.UrunGorsel;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}