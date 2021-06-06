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
    public class ValuesController : BaseController
    {
        private DongHoDbcontext db = new DongHoDbcontext();

        // GET: Admin/Values
        public ActionResult Index()
        {
            var values = db.Values.Include(v => v.altributes);
            return View(values.ToList());
        }

        // GET: Admin/Values/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Values values = db.Values.Find(id);
            if (values == null)
            {
                return HttpNotFound();
            }
            return View(values);
        }

        // GET: Admin/Values/Create
        public ActionResult Create()
        {
            ViewBag.ID_altribute = new SelectList(db.altributes, "ID_altribute", "name");
            return View();
        }

        // POST: Admin/Values/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Values,Value,ID_altribute,Created_At")] Values values)
        {
            if (ModelState.IsValid)
            {
                db.Values.Add(values);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_altribute = new SelectList(db.altributes, "ID_altribute", "name", values.ID_altribute);
            return View(values);
        }

        // GET: Admin/Values/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Values values = db.Values.Find(id);
            if (values == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_altribute = new SelectList(db.altributes, "ID_altribute", "name", values.ID_altribute);
            return View(values);
        }

        // POST: Admin/Values/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Values,Value,ID_altribute,Created_At")] Values values)
        {
            if (ModelState.IsValid)
            {
                db.Entry(values).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_altribute = new SelectList(db.altributes, "ID_altribute", "name", values.ID_altribute);
            return View(values);
        }

        // GET: Admin/Values/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Values values = db.Values.Find(id);
            if (values == null)
            {
                return HttpNotFound();
            }
            return View(values);
        }

        // POST: Admin/Values/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Values values = db.Values.Find(id);
            db.Values.Remove(values);
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
