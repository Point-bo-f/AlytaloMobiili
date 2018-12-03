using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlytaloMobiili.Models;
using AlytaloMobiili.ViewModels;

namespace AlytaloMobiili.Controllers
{
    public class SaunaController : Controller
    {
        private AlytaloEntities db = new AlytaloEntities();
        private object talosauna;

        // GET: Sauna
        public ActionResult Index()
        {
            List<SaunaViewModel> model = new List<SaunaViewModel>();

            AlytaloEntities entities = new AlytaloEntities();

            try
            {
                List<Saunat> talosaunat = entities.Saunat.OrderByDescending(Saunat => Saunat.SaunaNimi).ToList();

                // muodostetaan näkymämalli tietokannan rivien pohjalta
                foreach (Saunat talosauna in talosaunat)
                {
                    SaunaViewModel sauna = new SaunaViewModel();
                    sauna.SaunaId = talosauna.SaunaId;
                    sauna.SaunaNimi = talosauna.SaunaNimi;
                    sauna.TavoiteLampotila = talosauna.TavoiteLampotila;
                    sauna.NykyLampotila = talosauna.NykyLampotila;
                   
                    

                    return View(db.Saunat.ToList());
        }

                // GET: Sauna/Details/5
                SaunaViewModel model = new SaunaViewModel();
                AlytaloEntities entities = new AlytaloEntities();

                try
                {
                   Saunat taloSauna = db.Saunat.Find(id);
                    if (taloSauna == null)

                    {
                        return HttpNotFound();
                    }

                    Saunat saunadetail = entities.Saunat.Find(taloSauna.SaunaId);

                    SaunaViewModel sauna = new SaunaViewModel();
                    sauna.SaunaId = saunadetail.SaunaId;
                    sauna.SaunaNimi = saunadetail.SaunaNimi;
                    sauna.TavoiteLampotila = saunadetail.TavoiteLampotila;
                    sauna.NykyLampotila = saunadetail.NykyLampotila;
                    sauna.SaunaStart = saunadetail.SaunaStart.GetValueOrDefault();
                    sauna.SaunaStop = saunadetail.SaunaStop.GetValueOrDefault();
                    sauna.SaunanTila = saunadetail.SaunanTila;

                    model = sauna;

                }
                finally
                {
                    entities.Dispose();
                }

                return View(model);
            }

        // GET: Sauna/Create
            public ActionResult Create()
            {
                AlytaloEntities db = new AlytaloEntities();

                SaunaViewModel model = new SaunaViewModel();

                ViewBag.SaunaNimi = new SelectList((from ts in db.Saunat select new { Sauna_ID = ts.SaunaId, SaunanNimi = ts.SaunaNimi }), "SaunaId", "SaunaNimi", null);

                return View(model);
            }

        // POST: Sauna/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaunaViewModel model)
        {
            Saunat.sauna = new Saunat();
            sauna.SaunaId = model.SaunaId;
            sauna.SaunaNimi = model.SaunaNimi;
            //sauna.SaunaStart = model.SaunaStart;
            //sauna.SaunaStop = model.SaunaStop;                    
            sauna.TavoiteLampotila = model.TavoiteLampotila;
            sauna.NykyLampotila = model.NykyLampotila;
            //sauna.SaunanTila = model.SaunanTila;

            db.Saunat.Add(sauna);

            ViewBag.SaunaNimi = new SelectList((from ts in db.Saunat select new { Sauna_ID = ts.SaunaÏd, SaunaNimi = ts.SaunaNimi }), "SaunaId", "SaunaNimi", null);

            try
            {
                db.SaveChanges();
            }

            catch (Exception ex)
            {
            }

            return RedirectToAction("Index");

            // GET: Sauna/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Saunat taloSauna = db.Saunat.Find(id);
                if (taloSauna == null)
                {
                    return HttpNotFound();
                }

                SaunaViewModel sauna = new SaunaViewModel();
                sauna.SaunaId = taloSauna.SaunaId;
                sauna.SaunaNimi = taloSauna.SaunaNimi;
                sauna.TavoiteLampotila = taloSauna.TavoiteLampotila;
                sauna.NykyLampotila = taloSauna.NykyLampotila;
                //sauna.SaunaStart = taloSauna.SaunaStart.GetValueOrDefault();
                //sauna.SaunaStop = taloSauna.SaunaStop.GetValueOrDefault();
                //sauna.SaunanTila = taloSauna.SaunanTila;

                ViewBag.SaunanNimi = new SelectList((from ts in db.Saunat select new { Sauna_ID = ts.SaunaId, SaunaNimi = ts.SaunaNimi }), "SaunaId", "SaunaNimi", sauna.SaunaId);

                return View(sauna);
            }

        // POST: Sauna/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SaunaViewModel model)
        {
            Saunat sauna = db.Saunat.Find(model.SaunaId);
            sauna.SaunaNimi = model.SaunaNimi;
            sauna.TavoiteLampotila = model.TavoiteLampotila;
            sauna.NykyLampotila = model.NykyLampotila;
            //sauna.SaunaStart = DateTime.Now;
            //sauna.SaunaStop = DateTime.Now;
            //sauna.SaunanTila = model.SaunanTila;

            ViewBag.SaunaNimi = new SelectList((from ts in db.Saunat select new { Sauna_ID = ts.SaunaId, SaunaNimi = ts.SaunaNimi }), "SaunaId", "SaunaNimi", sauna.SaunaId);

            db.SaveChanges();

            return RedirectToAction("Index");
        }//edit

        // GET: TaloSauna/SaunaOn/5
        public ActionResult SaunaOn(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saunat taloSauna = db.Saunat.Find(id);
            if (taloSauna == null)
            {
                return HttpNotFound();
            }

            SaunaViewModel sauna = new SaunaViewModel();
            sauna.SaunaId = taloSauna.SaunaId;
            sauna.SaunaNimi = taloSauna.SaunaNimi;
            sauna.SaunaStart = taloSauna.SaunaStart;
            sauna.SaunanTila = true;

            ViewBag.SaunanNimi = new SelectList((from ts in db.Saunat select new { Sauna_ID = ts.SaunaId, SaunaNimi = ts.SaunaNimi }), "SaunaId", "SaunaNimi", sauna.SaunaId);

            return View(sauna);
        }

        // POST: TaloSauna/SaunaOn/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaunaOn(SaunaViewModel model)
        {
            Saunat sauna = db.Saunat.Find(model.SaunaId);
            sauna.SaunaNimi = model.SaunaNimi;
            sauna.SaunaStart = DateTime.Now;
            sauna.SaunanTila = true;

            ViewBag.SaunaNimi = new SelectList((from ts in db.Saunat select new { Sauna_ID = ts.SaunaId, SaunanNimi = ts.SaunaNimi }), "SaunaId", "SaunaNimi", sauna.SaunaId);

            db.SaveChanges();
            return RedirectToAction("Index");
        }//

        // GET: TaloSauna/SaunaOff/5
        public ActionResult SaunaOff(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saunat taloSauna = db.Saunat.Find(id);
            if (taloSauna == null)
            {
                return HttpNotFound();
            }

            SaunaViewModel sauna = new SaunaViewModel();
            sauna.SaunaId = taloSauna.SaunaId;
            sauna.SaunaNimi = taloSauna.SaunaNimi;
            sauna.SaunaStop = taloSauna.SaunaStop;
            sauna.SaunanTila = false;

            ViewBag.SaunanNimi = new SelectList((from ts in db.Saunat select new { Sauna_ID = ts.SaunaId, SaunaNimi = ts.SaunaNimi }), "SaunaId", "SaunaNimi", sauna.SaunaId);

            return View(sauna);
        }

        // POST: TaloSauna/SaunaOff/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaunaOff(SaunaViewModel model)
        {
            Saunat sauna = db.Saunat.Find(model.SaunaId);
            sauna.SaunaNimi = model.SaunaNimi;
            sauna.SaunaStop = DateTime.Now;
            sauna.SaunanTila = false;

            ViewBag.SaunanNimi = new SelectList((from ts in db.Saunat select new { Sauna_ID = ts.SaunaId, SaunaNimi = ts.SaunaNimi }), "SaunaId", "SaunaNimi", sauna.SaunaId);

            db.SaveChanges();
            return RedirectToAction("Index");
        }//


        // GET: TaloSauna/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saunat taloSauna = db.Saunat.Find(id);
            if (taloSauna == null)
            {
                return HttpNotFound();
            }

            SaunaViewModel sauna = new SaunaViewModel();
            sauna.SaunaId = taloSauna.SaunaId;
            sauna.SaunaNimi = taloSauna.SaunaNimi;
            sauna.TavoiteLampotila = taloSauna.TavoiteLampotila;
            sauna.NykyLampotila = taloSauna.NykyLampotila;
            sauna.SaunaStart = taloSauna.SaunaStart.GetValueOrDefault();
            sauna.SaunaStop = taloSauna.SaunaStop.GetValueOrDefault();
            sauna.SaunanTila = taloSauna.SaunanTila;

            return View(sauna);
        }

        // POST: TaloSauna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Saunat taloSauna = db.Saunat.Find(id);
            db.Saunat.Remove(taloSauna);
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