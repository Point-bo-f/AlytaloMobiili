using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlytaloMobiili.Models;

namespace AlytaloMobiili.Controllers
{
    public class ValoController : Controller
    {
        private AlytaloEntities db = new AlytaloEntities();

        // GET: Valo
        public ActionResult Index()
        {
            return View(db.Valot.ToList());
        }

        // GET: Valo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot valot = db.Valot.Find(id);
            if (valot == null)
            {
                return HttpNotFound();
            }
            return View(valot);
        }

        // GET: Valo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Valo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ValoId,Huone,ValoOff,ValoOn33,ValoOn66,ValoOn100")] Valot valot)
        {
            if (ModelState.IsValid)
            {
                db.Valot.Add(valot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valot);
        }

        // GET: Valo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot valot = db.Valot.Find(id);
            if (valot == null)
            {
                return HttpNotFound();
            }
            return View(valot);
        }

        // POST: Valo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ValoId,Huone,ValoOff,ValoOn33,ValoOn66,ValoOn100")] Valot valot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valot);
        }

        // GET: Valo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot valot = db.Valot.Find(id);
            if (valot == null)
            {
                return HttpNotFound();
            }
            return View(valot);
        }

        // POST: Valo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Valot valot = db.Valot.Find(id);
            db.Valot.Remove(valot);
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
