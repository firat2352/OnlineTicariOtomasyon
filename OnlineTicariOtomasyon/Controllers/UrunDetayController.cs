using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            CommonClass common = new CommonClass();
            //return View(_context.Uruns.Where(x => x.UrunId == 1).ToList());

            common.Deger1 = _context.Uruns.Where(x => x.UrunId == 1).ToList();
            common.Deger2 = _context.Detays.Where(x => x.DetayId == 1).ToList();

            return View(common);
        }
    }
}