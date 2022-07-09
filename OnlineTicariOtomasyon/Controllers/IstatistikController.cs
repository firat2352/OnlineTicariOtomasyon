""using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            var dgr1=_context.Caris.Count().ToString();
            ViewBag.cari = dgr1;

            var dgr2 = _context.Uruns.Count().ToString();
            ViewBag.urun = dgr2;

            var dgr3 = _context.Personels.Count().ToString();
            ViewBag.personel = dgr3;

            var dgr4 = _context.Kategories.Count().ToString();
            ViewBag.kategori = dgr4;

            var dgr5 = _context.Uruns.Sum(m => m.Stok).ToString();
            ViewBag.stok= dgr5;

            var dgr6 = _context.Uruns.Count(m => m.Stok < 20).ToString();
            ViewBag.kritik= dgr6;

            var dgr7 = (from x in _context.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.marka = dgr7;

            var dgr8 = (from x in _context.Uruns orderby x.SatisFiyat descending select x.UrunAdi).FirstOrDefault();
            ViewBag.maxUrun = dgr8;

            var dgr9 = (from x in _context.Uruns orderby x.SatisFiyat ascending select x.UrunAdi).FirstOrDefault();
            ViewBag.minUrun= dgr9;

            var dgr10 = _context.Uruns.Count(m => m.UrunAdi=="Buzdolabı").ToString();
            ViewBag.buzdolabiSayisi = dgr10;

            var dgr11 = _context.Uruns.Count(m => m.UrunAdi == "Laptop").ToString();
            ViewBag.laptopSayisi = dgr11;

            var dgr12 = _context.Uruns.GroupBy(m => m.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.maxMarka = dgr12;

            var dgr13 = (_context.Uruns.Where(u => u.UrunId == (_context.SatisHarekets.GroupBy(x => x.UrunId).OrderByDescending(y => y.Count()).Select(m => m.Key).FirstOrDefault())).Select(t => t.UrunAdi).FirstOrDefault());
            ViewBag.encokSatilan = dgr13;

            var dgr14 = _context.SatisHarekets.Sum(m => m.ToplamTutar).ToString();
            ViewBag.toplamSatis = dgr14;

            var dgr15 = _context.SatisHarekets.Count(m => m.Tarih==DateTime.Today).ToString();
            ViewBag.satisBugun= dgr15;

            var dgr16 = _context.SatisHarekets.Where(x => x.Tarih == DateTime.Today).Sum(y =>(decimal?) y.ToplamTutar).ToString();
            ViewBag.satisBugunToplam = dgr16;

            return View();
        }

        public ActionResult ProgressTable()
        {
            var sorgu = from x in _context.Caris
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };

            return View(sorgu.ToList());
        }

        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in _context.Personels
                         group x by x.Departman.DepartmanAd into g
                         select new SinifGrup2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult Partial2()
        {
            var sorgu = _context.Caris.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial3()
        {
            var sorgu = _context.Uruns.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial4()
        {

            var sorgu = from x in _context.Uruns
                         group x by x.Marka into g
                         select new SinifGrup3
                         {
                             Marka = g.Key,
                             sayi = g.Count()
                         };
            return PartialView(sorgu.ToList());
        }
    }
}