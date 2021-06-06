using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebsiteFPT.Models;

namespace WebsiteFPT.Controllers
{
    public class ProductController : Controller
    {
        private DongHoDbcontext db = new DongHoDbcontext();
        // GET: Product
        
        public ActionResult ShowProduct(int? id, string sortOrder, string searchString)
        {
            ViewBag.Message = "Product";
            var sanphams = db.Products.Include(s => s.Categories).Include(s => s.Prices).Include(s => s.Brands).ToList();
            ViewBag.DanhMuc = db.Categorys.ToList();
            ViewBag.TakeProduct = db.Products.ToList();
            ViewBag.Takebrand = db.Brands.ToList();
            ViewBag.TenSortParm = String.IsNullOrEmpty(sortOrder) ? "ten_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "price" ? "price_desc" : "price";
            if (id == null)
            {
                ViewBag.countPro = db.Products.Count();
                var models = db.Products.AsQueryable();
                if (!String.IsNullOrEmpty(searchString))
                {
                    models = models.Where(s => s.Name.Contains(searchString)
                                           || s.Categories.Name.Contains(searchString));
                                           
                }
                switch (sortOrder)
                {
                    case "ten_desc":
                        models = models.OrderByDescending(s => s.Name);
                        break;
                    case "price":
                        models = models.OrderBy(s => s.Prices.PromotionPrice);
                        break;
                    case "price_desc":
                        models = models.OrderByDescending(s => s.Prices.PromotionPrice);
                        break;
                    default:
                        models = models.OrderBy(s => s.ID_Price);
                        break;
                }
                return View(models.ToList());
            }
            else
            {
                ViewBag.countPro = db.Products.Where(s => s.Categories.ID_Category == id).Count();
                var models = db.Products.Where(s => s.Categories.ID_Category == id).AsQueryable();
                if (!String.IsNullOrEmpty(searchString))
                {
                    models = models.Where(s => s.Name.Contains(searchString)
                                           || s.Categories.Name.Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "ten_desc":
                        models = models.OrderByDescending(s => s.Name);
                        break;
                    case "price":
                        models = models.OrderBy(s => s.Prices.PromotionPrice);
                        break;
                    case "price_desc":
                        models = models.OrderByDescending(s => s.Prices.PromotionPrice);
                        break;
                    default:
                        models = models.OrderBy(s => s.ID_Price);
                        break;
                }
                return View(models.ToList());
            }


        }
        public ActionResult ProductDetail(long id )
        {
            ViewBag.pro = db.Products.Find(id);
            ViewBag.values = db.Values.ToList();
            return View();
        }

    }
}