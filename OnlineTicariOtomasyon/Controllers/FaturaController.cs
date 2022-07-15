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

        public ActionResult FaturaDetay(int id)
        {
            return View(_context.FaturaKalems.Where(m=>m.FaturaId==id).ToList());
        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem faturaKalem)
        {
            _context.FaturaKalems.Add(faturaKalem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Dinamik()
        {
            DinamikFatura dinamikFatura = new DinamikFatura();
            dinamikFatura.FaturaProp = _context.Faturas.ToList();
            dinamikFatura.FaturaKalemProp = _context.FaturaKalems.ToList();

            return View(dinamikFatura);
        }

        public ActionResult FaturaKaydet(string FaturaSeriNo,string FaturaSiraNo,DateTime Tarih,string VergiDairesi,string Saat,string TeslimEden,string TeslimAlan,string Toplam,FaturaKalem[] kalemler)
        {
            Fatura fatura = new Fatura();
            fatura.FaturaSeriNo = FaturaSeriNo;
            fatura.FaturaSiraNo = FaturaSiraNo;
            fatura.Tarih = Tarih;
            fatura.Saat = Saat;
            fatura.TeslimEden = TeslimEden;
            fatura.TeslimAlan = TeslimAlan;
            fatura.Toplam = decimal.Parse(Toplam);

            _context.Faturas.Add(fatura);

            foreach (var item in kalemler)
            {
                FaturaKalem faturaKalem = new FaturaKalem();
                faturaKalem.Aciklama = item.Aciklama;
                faturaKalem.BirimFiyat = item.BirimFiyat;
                faturaKalem.FaturaId = item.FaturaKalemId;
                faturaKalem.Miktar = item.Miktar;
                faturaKalem.Tutar = item.Tutar;

                _context.FaturaKalems.Add(faturaKalem);
               

            }
            _context.SaveChanges();

            return Json("Fatura Kaydı Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}