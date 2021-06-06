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
    public class attr_orderController : Controller
    {
        private DongHoDbcontext db = new DongHoDbcontext();

        // GET: Admin/attr_order
        public ActionResult Index()
        {
            var attr_Orders = db.Attr_Orders.Include(a => a.Orders).Include(a => a.Products);
            var results = (from od in db.Values_products
                           join o in db.Attr_Orders on od.ID_Values_product equals o.ID_attr_order
                           where o.ID_Product != 1

                           group od by new { od.ID_Values_product, o } into groupb
                           orderby groupb.Key.o.ID_Product descending
                           select new at
                           {
                               ID = groupb.Key.OrderId,
                               SAmount = groupb.Sum(m => m.Amount),
                               CustomerName = groupb.Key.o.DeliveryName,
                               Status = groupb.Key.o.Status,
                               CreateDate = groupb.Key.o.CreateDate,
                               ExportDate = groupb.Key.o.ExportDate,


                           });
            return View(attr_Orders.ToList());
        }

        // GET: Admin/attr_order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attr_order attr_order = db.Attr_Orders.Find(id);
            if (attr_order == null)
            {
                return HttpNotFound();
            }
            return View(attr_order);
        }

        // GET: Admin/attr_order/Create
        public ActionResult Create()
        {
            ViewBag.ID_Order = new SelectList(db.Orders, "ID_Order", "Note");
            ViewBag.ID_Product = new SelectList(db.Products, "ID_Product", "Name");
            return View();
        }

        // POST: Admin/attr_order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_attr_order,Color,Size,Status,Price,Quantity,ID_Order,ID_Product,Created_At")] attr_order attr_order)
        {
            if (ModelState.IsValid)
            {
                db.Attr_Orders.Add(attr_order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Order = new SelectList(db.Orders, "ID_Order", "Note", attr_order.ID_Order);
            ViewBag.ID_Product = new SelectList(db.Products, "ID_Product", "Name", attr_order.ID_Product);
            return View(attr_order);
        }

        // GET: Admin/attr_order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attr_order attr_order = db.Attr_Orders.Find(id);
            if (attr_order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Order = new SelectList(db.Orders, "ID_Order", "Note", attr_order.ID_Order);
            ViewBag.ID_Product = new SelectList(db.Products, "ID_Product", "Name", attr_order.ID_Product);
            return View(attr_order);
        }

        // POST: Admin/attr_order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_attr_order,Color,Size,Status,Price,Quantity,ID_Order,ID_Product,Created_At")] attr_order attr_order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attr_order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Order = new SelectList(db.Orders, "ID_Order", "Note", attr_order.ID_Order);
            ViewBag.ID_Product = new SelectList(db.Products, "ID_Product", "Name", attr_order.ID_Product);
            return View(attr_order);
        }

        // GET: Admin/attr_order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attr_order attr_order = db.Attr_Orders.Find(id);
            if (attr_order == null)
            {
                return HttpNotFound();
            }
            return View(attr_order);
        }

        // POST: Admin/attr_order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            attr_order attr_order = db.Attr_Orders.Find(id);
            db.Attr_Orders.Remove(attr_order);
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
