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
    public class ValoController : Controller
    {
        private AlytaloEntities db = new AlytaloEntities();

        // GET: Valo
        List<ValoViewModel> model = new List<ValoViewModel>();
        AlytaloEntities entities = new AlytaloEntities();

            try
            {
                List<Valot> talovalot = entities.Valot.OrderByDescending(Valot => Models.Valot.Huone).ToList();

                // muodostetaan näkymämalli tietokannan rivien pohjalta
                foreach (Valot talovalo in talovalot)
                {
                    ValoViewModel valo = new ValoViewModel();
                    valo.ValoId = talovalo.ValoId;
                    valo.Huone = talovalo.Huone;                    
                    valo.Valo33 = talovalo.Valo33;
                    valo.Valo66 = talovalo.Valo66;
                    valo.Valo100 = talovalo.Valo100;
                    valo.ValoOff = talovalo.ValoOff;

                    model.Add(valo);
                }
}
            finally
            {
                entities.Dispose();
            }

            return View(model);

        }

        // GET: Valo/Details/5
        public ActionResult Details(int? id)
{



        ValoViewModel model = new ValoViewModel();

AlytaloEntities entities = new AlytaloEntities();

            try
            {
               Valot taloValo = db.Valot.Find(id);
                if (taloValo == null)
                {
                    return HttpNotFound();
                }

                Valot valodetail = entities.Valot.Find(taloValo.ValoId);

                ValoViewModel valo = new ValoViewModel();
                valo.ValoId = valodetail.ValoId;
                valo.Huone = valodetail.Huone;                
                valo.Valo33 = valodetail.Valo33;
                valo.Valo66 = valodetail.Valo66;
                valo.Valo100 = valodetail.Valo100;
                valo.ValoOff = valodetail.ValoOff;

                model = valo;

            }
            finally
            {
                entities.Dispose();
            }

            return View(model);
        }

        // GET: Valo/Create
        public ActionResult Create()

        AlytaloEntities db = new AlytaloEntities();

        ValoViewModel model = new ValoViewModel();

            ViewBag.Huone = new SelectList((from tv in db.Valot select new { ValoId = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
           

            return View(model);
// POST: Valo/Create
// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
        [ValidateAntiForgeryToken]
public ActionResult Create(ValoViewModel model)
{
    Valot valo = new Valot();
    valo.ValoId = model.ValoId;
    valo.Huone = model.Huone;
    //valo.ValoOn33 = DateTime.Now;
    //valo.ValoOn66 = DateTime.Now;
    //valo.ValoOn100 = DateTime.Now;
    //valo.ValoOff = DateTime.Now;

    db.Valot.Add(valo);

    ViewBag.Huone = new SelectList((from tv in db.Valot select new { ValoId = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
    

    try
    {
        db.SaveChanges();
    }

    catch (Exception ex)
    {
    }

    return RedirectToAction("Index");
}//create*/;

// GET: TaloValo/Edit/5
public ActionResult Edit(int? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    TaloValo talovalo = db.TaloValo.Find(id);
    if (talovalo == null)
    {
        return HttpNotFound();
    }

    LightsViewModel valo = new LightsViewModel();
    valo.Valo_ID = talovalo.Valo_ID;
    valo.Huone = talovalo.Huone;
    valo.ValaisinType = talovalo.ValaisinType;
    valo.Lamppu_ID = talovalo.Lamppu_ID;
    //valo.ValoOn33 = DateTime.Now;
    //valo.ValoOn66 = DateTime.Now;
    //valo.ValoOn100 = DateTime.Now;
    //valo.ValoOff = DateTime.Now;

    ViewBag.Huone = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "Huone", null);
    ViewBag.ValaisinTYpe = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "ValaisinType", null);

    return View(valo);
}


// GET: Valo/Edit/5
public ActionResult Edit(ValoViewModel model)
{
    Valot valo = db.Valot.Find(model.ValoId);
    //valo.Valo_ID = model.Valo_ID;
    valo.Huone = model.Huone;
    //valo.ValoOn33 = DateTime.Now;
    //valo.ValoOn66 = DateTime.Now;
    //valo.ValoOn100 = DateTime.Now;
    //valo.ValoOff = DateTime.Now;

    ViewBag.Huone = new SelectList((from tv in db.Valot select new { ValoId = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
    

    db.SaveChanges();

    return RedirectToAction("Index");
}


// POST: Valo/Edit/5
// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
        [ValidateAntiForgeryToken]
public ActionResult Edit(ValoViewModel model)
{
    Valot valo = db.TaloValo.Find(model.ValoId);
    //valo.Valo_ID = model.Valo_ID;
    valo.Huone = model.Huone;
   //valo.ValoOn33 = DateTime.Now;
    //valo.ValoOn66 = DateTime.Now;
    //valo.ValoOn100 = DateTime.Now;
    //valo.ValoOff = DateTime.Now;

    ViewBag.Huone = new SelectList((from tv in db.Valot select new { ValoId = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
    

    db.SaveChanges();

    return RedirectToAction("Index");

    // GET: TaloValo/LightsOff/5
    public ActionResult ValoOff(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Valot talovalo = db.Valot.Find(id);
        if (talovalo == null)
        {
            return HttpNotFound();
        }

        ValoViewModel valo = new ValoViewModel();
        valo.ValoId = talovalo.ValoId;
        valo.Huone = talovalo.Huone;
        valo.Valo33 = false;
        valo.Valo66 = false;
        valo.Valo100 = false;
        valo.ValoOff = true;
        //valo.ValoOn33 = DateTime.Now;
        //valo.ValoOn66 = DateTime.Now;
        //valo.ValoOn100 = DateTime.Now;

        return View(valo);


    } // GET: TaloValo/Light33/5
    public ActionResult Valo33(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Valot talovalo = db.TaloValo.Find(id);
        if (talovalo == null)
        {
            return HttpNotFound();
        }

        ValoViewModel valo = new ValoViewModel();
        valo.ValoId = talovalo.ValoId;
        valo.Huone = talovalo.Huone;
        valo.Valo33 = true;
        valo.Valo66 = false;
        valo.Valo100 = false;
        valo.ValoOff = false;
        //valo.ValoOn33 = talovalo.ValoOn33;
        //valo.ValoOn66 = talovalo.ValoOn66;
        //valo.ValoOn100 = talovalo.ValoOn100;
        //valo.ValoOff = talovalo.ValoOff;

        ViewBag.Huone = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "Huone", null);
        ViewBag.ValaisinTYpe = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "ValaisinType", null);

        return View(valo);
    }

    public ActionResult Valo66(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Valot talovalo = db.TaloValo.Find(id);
        if (talovalo == null)
        {
            return HttpNotFound();
        }

        ValoViewModel valo = new ValoViewModel();
        valo.ValoId = talovalo.ValoId;
        valo.Huone = talovalo.Huone;
        valo.Valo33 = false;
        valo.Valo66 = true;
        valo.Valo100 = false;
        //valo.ValoOn33 = talovalo.ValoOn33;
        //valo.ValoOn66 = talovalo.ValoOn66;
        //valo.ValoOn100 = talovalo.ValoOn100;
        //valo.ValoOff = talovalo.ValoOff;

        ViewBag.Huone = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "Huone", null);
        ViewBag.ValaisinTYpe = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "ValaisinType", null);

        return View(valo);
    }

    public ActionResult Valo100(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Valot talovalo = db.TaloValo.Find(id);
        if (talovalo == null)
        {
            return HttpNotFound();
        }

        ValoViewModel valo = new ValoViewModel();
        valo.ValoId = talovalo.ValoId;
        valo.Huone = talovalo.Huone;
        valo.Valo33 = false;
        valo.Valo66 = false;
        valo.Valo100 = true;
        //valo.ValoTilaOff = false;
        //valo.ValoOn33 = talovalo.ValoOn33;
        //valo.ValoOn66 = talovalo.ValoOn66;
        //valo.ValoOn100 = talovalo.ValoOn100;
        //valo.ValoOff = talovalo.ValoOff;

        ViewBag.Huone = new SelectList((from tv in db.Valot select new { ValoId = tv.ValoId, Huone = tv.Huone }), "ValoId", "Huone", null);
        

        return View(valo);
    }

    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Valot talovalo = db.Valot.Find(id);
        if (talovalo == null)
        {
            return HttpNotFound();
        }

        ValoViewModel valo = new ValoViewModel();
        valo.ValoId = talovalo.ValoId;
        valo.Huone = talovalo.Huone;
        valo.Valo33 = talovalo.Valo33;
        valo.Valo66 = talovalo.Valo66;
        valo.Valo100 = talovalo.Valo100;
        valo.ValoOff = talovalo.ValoOff;

        return View(valo);
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
