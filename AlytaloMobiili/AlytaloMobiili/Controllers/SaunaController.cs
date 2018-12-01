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
    public class SaunaController : Controller
    {
        private AlytaloEntities db = new AlytaloEntities();

        // GET: Sauna
        public ActionResult Index()
        {
            return View(db.Saunat.ToList());
        }

        // GET: Sauna/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saunat saunat = db.Saunat.Find(id);
            if (saunat == null)
            {
                return HttpNotFound();
            }
            return View(saunat);
        }

        // GET: Sauna/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sauna/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaunaId,SaunaNimi,SaunaOff,SaunaOn,SaunaTavoiteLampotila,SaunaNykyLampotila")] Saunat saunat)
        {
            if (ModelState.IsValid)
            {
                db.Saunat.Add(saunat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(saunat);
        }

        // GET: Sauna/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saunat saunat = db.Saunat.Find(id);
            if (saunat == null)
            {
                return HttpNotFound();
            }
            return View(saunat);
        }

        // POST: Sauna/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaunaId,SaunaNimi,SaunaOff,SaunaOn,SaunaTavoiteLampotila,SaunaNykyLampotila")] Saunat saunat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saunat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(saunat);
        }

        // GET: Sauna/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saunat saunat = db.Saunat.Find(id);
            if (saunat == null)
            {
                return HttpNotFound();
            }
            return View(saunat);
        }

        // POST: Sauna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Saunat saunat = db.Saunat.Find(id);
            db.Saunat.Remove(saunat);
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
