using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            var toplamCari = _context.Caris.Count().ToString();
            ViewBag.toplamCari = toplamCari;

            var toplamUrun = _context.Uruns.Count().ToString();
            ViewBag.toplamUrun = toplamUrun;

            var toplamKategori = _context.Kategories.Count().ToString();
            ViewBag.toplamKategori = toplamKategori;

            var toplamSehir = (from x in _context.Caris select x.CariSehir).Distinct().Count().ToString();
            ViewBag.toplamSehir = toplamSehir;

            var yapilacaklar = _context.Todos.ToList();
            return View(yapilacaklar);
        }
    }
}