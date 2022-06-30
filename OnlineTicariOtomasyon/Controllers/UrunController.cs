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
    }
}