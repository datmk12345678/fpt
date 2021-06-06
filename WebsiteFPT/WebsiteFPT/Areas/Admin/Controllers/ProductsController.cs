using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteFPT.Extensions;
using WebsiteFPT.Models;

namespace WebsiteFPT.Areas.Admin.Controllers
{
    public class ProductsController : BaseController
    {
        private DongHoDbcontext db = new DongHoDbcontext();

        // GET: Admin/Products
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TenSortParm = String.IsNullOrEmpty(sortOrder) ? "ten_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "price" ? "price_desc" : "price";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

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
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(models.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.ID_Brand = new SelectList(db.Brands, "ID_Brand", "Name");
            ViewBag.ID_Price = new SelectList(db.Prices, "ID_Price", "Prices");           
            ViewBag.ID_Category = new SelectList(db.Categorys, "ID_Category", "Name");
            ViewBag.values = db.Values.ToList();
            ViewBag.thuoctinhs = db.altributes.ToList();
            ViewBag.variants = db.Variants.ToList();
            ViewBag.bientheSPs = db.Values_products.ToList();
            ViewBag.SP = db.Prices.ToList();
           
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Product,Name,Code,Description,Image,Image1,Image2,Image3,ID_Price,Quantity,ID_Brand,ID_Trending,ID_Category,Detail,Guarantee,Status,Created_At")] Product product, HttpPostedFileBase[] hinh_anh, int[] values, int[] variants)
        {
            if (ModelState.IsValid)
            {
                foreach(var item in hinh_anh)
                {
                    var path = Path.Combine(Server.MapPath("~/Images/"), Path.GetFileName(item.FileName));
                    item.SaveAs(path);
                }
                var productsave = db.Products.Add(new Product
                {
                    Name = product.Name,
                    Code = product.Code,
                    Description = product.Description,
                    Image = "/Images/" + hinh_anh[0].FileName,
                    Image1 = "/Images/" + hinh_anh[1].FileName,
                    Image2 = "/Images/" + hinh_anh[2].FileName,
                    Image3 = "/Images/" + hinh_anh[3].FileName,

                    ID_Price = product.ID_Price,
                    Quantity = product.Quantity,
                    
                    ID_Brand = product.ID_Brand,
                    
                    ID_Category = product.ID_Category,
                    Detail = product.Detail,
                    Guarantee = product.Guarantee,
                    Hot = product.Hot,
                    Gioitinh = product.Gioitinh,
                    Status = product.Status,
                    Created_At = DateTime.Now
                });


                foreach (var value in values)
                {
                    db.Values_products.Add(new Values_product
                    {
                        ID_Values = value,
                        ID_Product = productsave.ID_Product,
                        Created_At = DateTime.Now
                    });
                    db.SaveChanges();
                }

                //foreach (var variant in variants)
                //{
                //    db.VariantValues.Add(new VariantValue
                //    {
                //        ID_VariantValue = variant,
                //        ID_Variant = variant,
                //        ID_Values = variant,
                //        Created_At = DateTime.Now
                //    });
                //    db.SaveChanges();
                //}
                this.AddNotification("Thêm sản phẩm thành công !!!", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }

            ViewBag.ID_Brand = new SelectList(db.Brands, "ID_Brand", "Name");
            ViewBag.ID_Price = new SelectList(db.Prices, "ID_Price", "Prices");
            ViewBag.ID_Category = new SelectList(db.Categorys, "ID_Category", "Name");
            ViewBag.values = db.Values.ToList();
            ViewBag.thuoctinhs = db.altributes.ToList();
            ViewBag.variants = db.Variants.ToList();
            ViewBag.bientheSPs = db.Values_products.ToList();
            ViewBag.SP = db.Prices.ToList();
            this.AddNotification("Thêm sản phẩm thành công !!!", NotificationType.SUCCESS);
            return View(product);

        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Brand = new SelectList(db.Brands, "ID_Brand", "Name");
            ViewBag.ID_Price = new SelectList(db.Prices, "ID_Price", "Prices");
            ViewBag.ID_Category = new SelectList(db.Categorys, "ID_Category", "Name");
            ViewBag.values = db.Values.ToList();
            ViewBag.thuoctinhs = db.altributes.ToList();
            ViewBag.thuoctinhsps = db.Values_products.Where(s => s.ID_Product==id).ToList();
            ViewBag.SP = db.Prices.ToList();
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Product,Name,Code,Description,Image,Image1,Image2,Image3,ID_Price,Quantity,ID_Brand,ID_Trending,Detail,Guarantee,Created_At")] Product product, HttpPostedFileBase hinh_anh, int[] values)
        {
            if (ModelState.IsValid)
            {
                string _FileName = Path.GetFileName(hinh_anh.FileName);
                string _path = Path.Combine(Server.MapPath("~/Images"), _FileName);
                hinh_anh.SaveAs(_path);
                var sp = new Product
                {
                    ID_Product = product.ID_Product,
                    Name = product.Name,
                    Code = product.Code,
                    Description = product.Description,
                    Image = "/Images/" + hinh_anh.FileName,
                    Image1 = "/Images/" + hinh_anh.FileName,
                    Image2 = "/Images/" + hinh_anh.FileName,
                    Image3 = "/Images/" + hinh_anh.FileName,

                    ID_Price = product.ID_Price,
                    Quantity = product.Quantity,

                    ID_Brand = product.ID_Brand,

                    ID_Category = product.ID_Category,
                    Detail = product.Detail,
                    Guarantee = product.Guarantee,
                    Hot = product.Hot,
                    Gioitinh = product.Gioitinh,
                    Status = product.Status,
                    Created_At = DateTime.Now
                };
             

                foreach (var value in values)
                {
                    db.Values_products.Add(new Values_product
                    {
                        ID_Values = value,
                        ID_Product = sp.ID_Product,
                        Created_At = DateTime.Now
                    });
                    db.SaveChanges();
                }

                db.Entry(sp).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Message = "Update Successfully!!";
                db.SaveChanges();
                this.AddNotification("Cập nhật thành công !!!", NotificationType.SUCCESS);
                return RedirectToAction("Index");

            }
            ViewBag.ID_Brand = new SelectList(db.Brands, "ID_Brand", "Name", product.ID_Brand);
            ViewBag.ID_Price = new SelectList(db.Prices, "ID_Price", "ID_Price", product.ID_Price);
            ViewBag.ID_Category = new SelectList(db.Categorys, "ID_Category", "Name");

            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
           
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            this.AddNotification("Bạn đã xóa thành công !!!", NotificationType.WARNING);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
