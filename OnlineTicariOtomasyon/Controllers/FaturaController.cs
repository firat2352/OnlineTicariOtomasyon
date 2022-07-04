using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            return View(_context.Faturas.ToList());
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Fatura fatura)
        {
            var faturaFind=_context.Faturas.Add(fatura);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var findFatura=_context.Faturas.Find(id);
            return View(findFatura);
        }

        public ActionResult FaturaGuncelle(Fatura fatura)
        {
            var faturaFind=_context.Faturas.Find(fatura.FaturaId);
            faturaFind.FaturaSeriNo = fatura.FaturaSeriNo;
            faturaFind.FaturaSiraNo = fatura.FaturaSiraNo;
            faturaFind.Saat = fatura.Saat;
            faturaFind.Tarih = fatura.Tarih;
            faturaFind.TeslimAlan = fatura.TeslimAlan;
            faturaFind.TeslimEden = fatura.TeslimEden;
            faturaFind.VergiDairesi = fatura.VergiDairesi;

            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}