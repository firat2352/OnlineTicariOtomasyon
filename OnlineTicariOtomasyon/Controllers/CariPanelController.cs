using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        Context _context = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var mail = Session["CariMail"].ToString();
            var result = _context.Mesajs.Where(x => x.Alici == mail).ToList();
            var mailId = _context.Caris.Where(x => x.CariMail == mail).Select(y => y.CariId).FirstOrDefault();
            ViewBag.mailId = mailId;
            var toplamSatis = _context.SatisHarekets.Where(x => x.CariId == mailId).Count();
            ViewBag.toplamSatis = toplamSatis;
            ViewBag.Mail = mail;
            var toplamTutar = _context.SatisHarekets.Where(x => x.CariId == mailId).Sum(y => y.ToplamTutar);
            ViewBag.toplamTutar = toplamTutar;
            var toplamUrunSayisi = _context.SatisHarekets.Where(x => x.CariId == mailId).Sum(y => y.Adet);
            ViewBag.toplamUrunSayisi = toplamUrunSayisi;

            var adSoyad = _context.Caris.Where(x => x.CariMail == mail).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.adSoyad = adSoyad;

            return View(result);
        }

        public ActionResult Siparislerim()
        {
            var mail = Session["CariMail"].ToString();
            var id = _context.Caris.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariId).FirstOrDefault();
            var degerler = _context.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(degerler);
        }

        public ActionResult GelenMesajlar()
        {
            var mail = Session["CariMail"].ToString();

            var mesajlar = _context.Mesajs.Where(x => x.Alici == mail).OrderByDescending(x=>x.MesajID).ToList();

            var gelenMesajSayisi = _context.Mesajs.Count(x => x.Alici == mail).ToString();
            ViewBag.gelenMesajSayisi = gelenMesajSayisi;

            var gidenMesajSayisi = _context.Mesajs.Count(x => x.Gonderici == mail).ToString();
            ViewBag.gidenMesajSayisi = gidenMesajSayisi;

            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var mail = Session["CariMail"].ToString();

            var mesajlar = _context.Mesajs.Where(x => x.Gonderici == mail).OrderByDescending(z=>z.MesajID).ToList();

            var gidenMesajSayisi = _context.Mesajs.Count(x => x.Gonderici == mail).ToString();
            ViewBag.gidenMesajSayisi = gidenMesajSayisi;

            var gelenMesajSayisi = _context.Mesajs.Count(x => x.Alici == mail).ToString();
            ViewBag.gelenMesajSayisi = gelenMesajSayisi;

            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var mesaj = _context.Mesajs.Where(m => m.MesajID == id).ToList();

            var mail = Session["CariMail"].ToString();

            var gelenMesajSayisi = _context.Mesajs.Count(x => x.Alici == mail).ToString();
            ViewBag.gelenMesajSayisi = gelenMesajSayisi;

            var gidenMesajSayisi = _context.Mesajs.Count(x => x.Gonderici == mail).ToString();
            ViewBag.gidenMesajSayisi = gidenMesajSayisi;

            return View(mesaj);
        }


        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = Session["CariMail"].ToString();

            var gelenMesajSayisi = _context.Mesajs.Count(x => x.Alici == mail).ToString();
            ViewBag.gelenMesajSayisi = gelenMesajSayisi;

            var gidenMesajSayisi = _context.Mesajs.Count(x => x.Gonderici == mail).ToString();
            ViewBag.gidenMesajSayisi = gidenMesajSayisi;
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Mesaj mesaj)
        {
            var mail = Session["CariMail"].ToString();
            mesaj.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            mesaj.Gonderici = mail;

            _context.Mesajs.Add(mesaj);
            _context.SaveChanges();
            return View();
        }

        
        public ActionResult KargoTakip(string kargo)
        {
            var kargolar = from item in _context.KargoDetays select item;
                
            kargolar = kargolar.Where(x => x.TakipKodu.Contains(kargo));
            
            return View(kargolar.ToList());

        }

        public ActionResult CariKargoTakip(string id)
        {
            var kayitlar = _context.KargoTakips.Where(m => m.TakipKodu == id).ToList();

            return View(kayitlar);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult Partial1()
        {
            var mail = Session["CariMail"].ToString();
            var id = _context.Caris.Where(x => x.CariMail == mail).Select(y => y.CariId).FirstOrDefault();
            var cari = _context.Caris.Find(id);

            return PartialView("Partial1", cari);
        }
    }
}