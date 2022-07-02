using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            var departmanlar = _context.Departmans.Where(m=>m.Durum==true).ToList();
            return View(departmanlar);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            departman.Durum = true;
            _context.Departmans.Add(departman);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var cari = _context.Departmans.Find(id);
            cari.Durum = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            return View(_context.Departmans.Find(id));
        }

        public ActionResult DepartmanGuncelle(Departman departman)
        {
            Departman dpr=_context.Departmans.Find(departman.DepartmanId);
            dpr.DepartmanAd = departman.DepartmanAd;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var personels = _context.Personels.Where(m => m.PersonelId == id).ToList();
            var departman = _context.Departmans.Where(m => m.DepartmanId == id).Select(m => m.DepartmanAd).FirstOrDefault();

            ViewBag.departmanAdi = departman;
            return View(personels);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var satislar = _context.SatisHarekets.Where(m => m.PersonelId == id).ToList();

            var personel=_context.Personels.Find(id);
            ViewBag.departmanPersonel = personel.PersonelAd +" "+personel.PersonelSoyad;
            return View(satislar);
        }
    }
}