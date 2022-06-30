using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            var kategories=_context.Kategories.ToList();
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
            _context.Kategories.Add(kategori);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult KategoriSil(int id)
        {
            var kategori=_context.Kategories.Find(id);
            _context.Kategories.Remove(kategori);
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