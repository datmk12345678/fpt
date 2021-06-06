using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteFPT.Models;

namespace WebsiteFPT.Areas.Admin.Controllers
{
    public class Values_productController : Controller
    {
        private DongHoDbcontext db = new DongHoDbcontext();

        // GET: Admin/Values_product
        public ActionResult Index()
        {
            var values_products = db.Values_products.Include(v => v.Products).Include(v => v.Values);
            return View(values_products.ToList());
        }

        // GET: Admin/Values_product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Values_product values_product = db.Values_products.Find(id);
            if (values_product == null)
            {
                return HttpNotFound();
            }
            return View(values_product);
        }

        // GET: Admin/Values_product/Create
        public ActionResult Create()
        {
            ViewBag.ID_Product = new SelectList(db.Products, "ID_Product", "Name");
            ViewBag.ID_Values = new SelectList(db.Values, "ID_Values", "Value");
            return View();
        }

        // POST: Admin/Values_product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Values_product,ID_Values,ID_Product,Created_At")] Values_product values_product)
        {
            if (ModelState.IsValid)
            {
                db.Values_products.Add(values_product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Product = new SelectList(db.Products, "ID_Product", "Name", values_product.ID_Product);
            ViewBag.ID_Values = new SelectList(db.Values, "ID_Values", "Value", values_product.ID_Values);
            return View(values_product);
        }

        // GET: Admin/Values_product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Values_product values_product = db.Values_products.Find(id);
            if (values_product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Product = new SelectList(db.Products, "ID_Product", "Name", values_product.ID_Product);
            ViewBag.ID_Values = new SelectList(db.Values, "ID_Values", "Value", values_product.ID_Values);
            return View(values_product);
        }

        // POST: Admin/Values_product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Values_product,ID_Values,ID_Product,Created_At")] Values_product values_product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(values_product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Product = new SelectList(db.Products, "ID_Product", "Name", values_product.ID_Product);
            ViewBag.ID_Values = new SelectList(db.Values, "ID_Values", "Value", values_product.ID_Values);
            return View(values_product);
        }

        // GET: Admin/Values_product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Values_product values_product = db.Values_products.Find(id);
            if (values_product == null)
            {
                return HttpNotFound();
            }
            return View(values_product);
        }

        // POST: Admin/Values_product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Values_product values_product = db.Values_products.Find(id);
            db.Values_products.Remove(values_product);
            db.SaveChanges();
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
