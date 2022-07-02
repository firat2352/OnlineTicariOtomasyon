using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            return View(_context.Caris.Where(m=>m.Durum==true).ToList());
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cari cari)
        {
            cari.Durum = true;
            _context.Caris.Add(cari);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var cari=_context.Caris.Find(id);
            cari.Durum = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}