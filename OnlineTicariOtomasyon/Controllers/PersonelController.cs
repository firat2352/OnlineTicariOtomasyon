using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.IO;
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
            if(Request.Files.Count>0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti= Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Images/" + dosyaAdi + uzanti;

            }

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
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                personel.PersonelGorsel = "/Images/" + dosyaAdi + uzanti;

            }
            var personelFind=_context.Personels.Find(personel.PersonelId);
            personelFind.PersonelAd = personel.PersonelAd;
            personelFind.PersonelSoyad = personel.PersonelSoyad;
            personelFind.PersonelGorsel = personel.PersonelGorsel;
            personelFind.DepartmanId = personel.DepartmanId;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelYeniTema()
        {
            
            return View(_context.Personels.ToList());
        }
    }
}