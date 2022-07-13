using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        Context _context = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var mail = Session["CariMail"].ToString();
            var result = _context.Caris.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.Mail = mail;
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

            var mesajlar = _context.Mesajs.Where(x => x.Alici == mail).ToList();

            var gelenMesajSayisi = _context.Mesajs.Count(x => x.Alici == mail).ToString();
            ViewBag.gelenMesajSayisi = gelenMesajSayisi;

            var gidenMesajSayisi = _context.Mesajs.Count(x => x.Gonderici == mail).ToString();
            ViewBag.gidenMesajSayisi = gidenMesajSayisi;

            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var mail = Session["CariMail"].ToString();

            var mesajlar = _context.Mesajs.Where(x => x.Gonderici == mail).ToList();

            var gidenMesajSayisi = _context.Mesajs.Count(x => x.Gonderici == mail).ToString();
            ViewBag.gidenMesajSayisi = gidenMesajSayisi;

            var gelenMesajSayisi = _context.Mesajs.Count(x => x.Alici == mail).ToString();
            ViewBag.gelenMesajSayisi = gelenMesajSayisi;

            return View(mesajlar);
        }

        //    [HttpGet]
        //    public ActionResult YeniMesaj()
        //    {
        //        return View();
        //    }

        //    [HttpPost]
        //    public ActionResult YeniMesaj()
        //    {
        //        return View();
        //    }
    }
}