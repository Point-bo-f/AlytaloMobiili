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
    public class TaloController : Controller
    {
        private AlytaloEntities db = new AlytaloEntities();

        // GET: Talo
        public ActionResult Index()
        {
            return View(db.Talot.ToList());
        }

        // GET: Talo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talot talot = db.Talot.Find(id);
            if (talot == null)
            {
                return HttpNotFound();
            }
            return View(talot);
        }

        // GET: Talo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Talo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaloId,TaloNimi,TaloTavoiteLampotila,TaloNykyLampotila,LampoOff,LampoOn")] Talot talot)
        {
            if (ModelState.IsValid)
            {
                db.Talot.Add(talot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(talot);
        }

        // GET: Talo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talot talot = db.Talot.Find(id);
            if (talot == null)
            {
                return HttpNotFound();
            }
            return View(talot);
        }

        // POST: Talo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaloId,TaloNimi,TaloTavoiteLampotila,TaloNykyLampotila,LampoOff,LampoOn")] Talot talot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(talot);
        }

        // GET: Talo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talot talot = db.Talot.Find(id);
            if (talot == null)
            {
                return HttpNotFound();
            }
            return View(talot);
        }

        // POST: Talo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Talot talot = db.Talot.Find(id);
            db.Talot.Remove(talot);
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
