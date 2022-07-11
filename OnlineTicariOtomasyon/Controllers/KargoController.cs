using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
           

            var kargolar=_context.KargoDetays.ToList();
            return View(kargolar);
        }

        [HttpGet]
        public ActionResult YeniKargo()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[9];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            ViewBag.takipKodu = finalString;
            return View();
        }

        [HttpPost]
        public ActionResult YeniKargo(KargoDetay kargoDetay)
        {
            _context.KargoDetays.Add(kargoDetay);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}