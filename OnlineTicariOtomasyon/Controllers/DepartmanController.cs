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
    }
}