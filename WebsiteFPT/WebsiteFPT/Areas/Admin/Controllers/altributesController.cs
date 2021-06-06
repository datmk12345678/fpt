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
    public class altributesController : BaseController
    {
        private DongHoDbcontext db = new DongHoDbcontext();

        // GET: Admin/altributes
        public ActionResult Index()
        {
            return View(db.altributes.ToList());
        }

        // GET: Admin/altributes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            altribute altribute = db.altributes.Find(id);
            if (altribute == null)
            {
                return HttpNotFound();
            }
            return View(altribute);
        }

        // GET: Admin/altributes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/altributes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_altribute,name,Created_At")] altribute altribute)
        {
            if (ModelState.IsValid)
            {
                db.altributes.Add(altribute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(altribute);
        }

        // GET: Admin/altributes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            altribute altribute = db.altributes.Find(id);
            if (altribute == null)
            {
                return HttpNotFound();
            }
            return View(altribute);
        }

        // POST: Admin/altributes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_altribute,name,Created_At")] altribute altribute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(altribute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(altribute);
        }

        // GET: Admin/altributes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            altribute altribute = db.altributes.Find(id);
            if (altribute == null)
            {
                return HttpNotFound();
            }
            return View(altribute);
        }

        // POST: Admin/altributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            altribute altribute = db.altributes.Find(id);
            db.altributes.Remove(altribute);
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
