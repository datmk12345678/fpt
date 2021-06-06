using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebsiteFPT.Models;

namespace WebsiteFPT.Controllers
{
    public class HomeController : Controller
    {
        private DongHoDbcontext db = new DongHoDbcontext();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.newProducts = db.Products.Include(s => s.Prices).Take(3);
            ViewBag.popularProducts = db.Products.Include(s => s.Prices).Take(6);
            ViewBag.message = "Home";
            return View();
        }
    }
}