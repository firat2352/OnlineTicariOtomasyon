﻿using OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            return View(_context.Uruns.ToList());
        }
    }
}