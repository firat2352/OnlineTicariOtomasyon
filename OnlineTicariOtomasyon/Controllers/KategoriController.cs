using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        Context _context = new Context();
        public ActionResult Index(int sayfa=1)
        {
            var kategories=_context.Kategories.Where(m=>m.Durum==true).ToList().ToPagedList(sayfa,4);
            return View(kategories);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            kategori.Durum = true;
            _context.Kategories.Add(kategori);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult KategoriSil(int id)
        {
            var katgori = _context.Kategories.Find(id);
            katgori.Durum = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori=_context.Kategories.Find(id);
            return View(kategori);
        }

        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            var ktgr=_context.Kategories.Find(kategori.KategoriId);
            ktgr.KategoriAd = kategori.KategoriAd;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}