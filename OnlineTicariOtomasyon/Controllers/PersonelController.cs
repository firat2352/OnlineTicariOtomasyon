using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            return View(_context.Personels.ToList());
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> liste = (from departman in _context.Departmans.ToList()
                                          select new SelectListItem
                                          {
                                              Text = departman.DepartmanAd,
                                              Value = departman.DepartmanId.ToString()
                                          }).ToList();

            ViewBag.DropDownListe = liste;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            _context.Personels.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> liste = (from departman in _context.Departmans.ToList()
                                          select new SelectListItem
                                          {
                                              Text = departman.DepartmanAd,
                                              Value = departman.DepartmanId.ToString()
                                          }).ToList();

            ViewBag.DropDownListe = liste;
            var personel = _context.Personels.Find(id);
            return View(personel);
        }

        public ActionResult PersonelGuncelle(Personel personel)
        {
            var personelFind=_context.Personels.Find(personel.PersonelId);
            personelFind.PersonelAd = personel.PersonelAd;
            personelFind.PersonelSoyad = personel.PersonelSoyad;
            personelFind.PersonelGorsel = personel.PersonelGorsel;
            personelFind.DepartmanId = personel.DepartmanId;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}