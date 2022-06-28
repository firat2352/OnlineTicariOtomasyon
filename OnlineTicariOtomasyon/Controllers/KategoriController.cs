using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        public ActionResult Index()
        {
            Context context = new Context();
            var kategories=context.Kategories.ToList();
            return View(kategories);
        }
    }
}