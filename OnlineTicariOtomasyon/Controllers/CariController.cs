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
            return View(_context.Caris.ToList());
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cari cari)
        {
            _context.Caris.Add(cari);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}