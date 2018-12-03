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
    public class TaloController : Controller
    {
        private AlytaloEntities db = new AlytaloEntities();

        // GET: Talo
        public ActionResult Index()
        {
            List<TaloViewModel> model = new List<TaloViewModel>();

            AlytaloEntities entities = new AlytaloEntities();

            try
            {
                List<Talot> talolammot = entities.Talot.OrderByDescending(Talot =>Talot.Huone).ToList();

                // muodostetaan näkymämalli tietokannan rivien pohjalta
                foreach (Talot talolammot in talolammot)
                {
                    TaloViewModel lampo = new TaloViewModel();
                    lampo.NykyLampotila = talolammot.NykyLampotila;
                    lampo.TavoiteLampotila = talolammot.TavoiteLampotila;
                    lampo.LampoOn = talolammot.LampoOn;
                    lampo.LampoOff = talolammot.LampoOff;

                    model.Add(lampo);
                }
            }
            finally
            {
                entities.Dispose();
            }

            return View(model);

        }
        // GET: Talo/Details/5
        public ActionResult Details(int? id)
        {
            TaloViewModel model = new TaloViewModel();

            AlytaloEntities entities = new AlytaloEntities();

            try
            {
                Talot taloLampo = db.Talot.Find(id);
                if (taloLampo == null)
                {
                    return HttpNotFound();
                }

                Talot lampodetail = entities.Talot.Find(Talot.TaloId);

                TaloViewModel lampo = new TaloViewModel();
                lampo.TaloId = lampodetail.TaloId;
                lampo.NykyLampotila = lampodetail.NykyLampotila;
                lampo.TavoiteLampotila = lampodetail.TavoiteLampotila;
                lampo.LampoOn = lampodetail.LampoOn;
                lampo.LampoOff = lampodetail.LampoOff;

                model = lampo;

            }
            finally
            {
                entities.Dispose();
            }

            return View(model);
        }

        // GET: Talo/Create
        public ActionResult Create()
        {
            AlytaloEntities db = new AlytaloEntities();

            TaloViewModel model = new TaloViewModel();

            return View(model);
        }

        // POST: Talo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LampoViewModel model)
        {
            Talot lampo = new Talot();
            lampo.HuoneId = model.HuoneId;
            lampo.NykyLampotila = model.NykyLampotila;
            lampo.TavoiteLampotila = model.TavoiteLampotila;
            //lampo.LampoKirjattu = model.LampoKirjattu;

            db.Talot.Add(lampo);

            try
            {
                db.SaveChanges();
            }

            catch (Exception ex)
            {
            }

            return RedirectToAction("Index");
        }//create*/
    }

    // GET: Talo/Edit/5
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Talot talolampo = db.Talot.Find(id);
        if (talolampo == null)
        {
            return HttpNotFound();
        }

        TaloViewModel lampo = new TaloViewModel();
        lampo.HuoneId = talolampo.HuoneId;
        lampo.NykyLampotila = talolampo.NykyLampotila;
        lampo.TavoiteLampotila = talolampo.TavoiteLampotila;
        //lampo.LampoKirjattu = talolampo.LampoKirjattu;

        return View(lampo);
    }

    // POST: Talo/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
        [ValidateAntiForgeryToken]
    public ActionResult Edit(TaloViewModel model)
    {
        Talot lampo = db.TaloLampo.Find(model.TaloId);
        //lampo.Huone_ID = model.Huone_ID;
        lampo.NykyLampotila = model.NykyLampotila;
        lampo.TavoiteLampotila = model.TavoiteLampotila;

        db.SaveChanges();
        return RedirectToAction("Index");
    }

    
        }

    // GET: TaloLampo/LampoON/5
    public ActionResult LampoON(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Talot talolampo = db.Talot.Find(id);
        if (talolampo == null)
        {
            return HttpNotFound();
        }

        TaloViewModel lampo = new TaloViewModel();
        lampo.TaloId = talolampo.TaloId;
        //lampo.HuoneNykyLampo = talolampo.HuoneNykyLampo;
        //lampo.HuoneTavoiteLampo = talolampo.HuoneTavoiteLampo;
        lampo.LampoOn = true;
        lampo.LampoOff = false;
        //lampo.LampoKirjattu = talolampo.LampoKirjattu;

        return View(lampo);
    }

    // POST: TaloLampo/LampoON/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult LampoON(TaloViewModel model)
    {
        Talot lampo = db.Talot.Find(model.TaloId);
        lampo.LampoOn = true;
        lampo.LampoOff = false;
        //lampo.HuoneNykyLampo = model.HuoneNykyLampo;
        //lampo.HuoneTavoiteLampo = model.HuoneTavoiteLampo;
        //lampo.LampoKirjattu = DateTime.Now;

        db.SaveChanges();
        return RedirectToAction("Index");
    }

    // GET: TaloLampo/LampoOFF/5
    public ActionResult LampoOFF(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Talot talolampo = db.Talot.Find(id);
        if (talolampo == null)
        {
            return HttpNotFound();
        }

        TaloViewModel lampo = new TaloViewModel();
        lampo.TaloId = talolampo.TaloId;
        //lampo.Huone = talolampo.Huone;
        //lampo.HuoneNykyLampo = talolampo.HuoneNykyLampo;
        //lampo.HuoneTavoiteLampo = talolampo.HuoneTavoiteLampo;
        lampo.LampoOn = false;
        lampo.LampoOff = true;
        //lampo.LampoKirjattu = talolampo.LampoKirjattu;

        return View(lampo);
    }

    // POST: TaloLampo/LampoOFF/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult LampoOFF(TaloViewModel model)
    {
        Talot lampo = db.TaloLampo.Find(model.TaloId);
        //lampo.Huone_ID = model.Huone_ID;
        //lampo.Huone = model.Huone;
        lampo.LampoOn = false;
        lampo.LampoOff = true;
        //lampo.HuoneNykyLampo = model.HuoneNykyLampo;
        //lampo.HuoneTavoiteLampo = model.HuoneTavoiteLampo;
        //lampo.LampoKirjattu = DateTime.Now;

        db.SaveChanges();
        return RedirectToAction("Index");
    }

// GET: Talo/Delete/5
        public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Talot talolampo = db.Talot.Find(id);
        if (talolampo == null)
        {
            return HttpNotFound();
        }

        TaloViewModel lampo = new TaloViewModel();
        lampo.TaloId = talolampo.TaloId;
        //lampo.Huone = talolampo.Huone;
        lampo.NykyLampotila = talolampo.NykyLampotila;
        lampo.TavoiteLampotila = talolampo.TavoiteLampotila;
        //lampo.LampoKirjattu = talolampo.LampoKirjattu;
        lampo.LampoOn = talolampo.LampoOn;
        lampo.LampoOff = talolampo.LampoOff;

        return View(lampo);
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
