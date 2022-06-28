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
    }
}