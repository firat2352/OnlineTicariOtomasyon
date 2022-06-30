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
            var departmanlar = _context.Departmans.ToList();
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
            _context.Departmans.Add(departman);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            Departman departman=_context.Departmans.Find(id);
            _context.Departmans.Remove(departman);
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
    }
}