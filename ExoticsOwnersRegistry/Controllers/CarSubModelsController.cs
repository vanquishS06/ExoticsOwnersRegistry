using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExoticsOwnersRegistry.Models;

namespace ExoticsOwnersRegistry.Controllers
{
    public class CarSubModelsController : Controller
    {
        private ExoticsOwnersRegistryContext db = new ExoticsOwnersRegistryContext();

        // GET: CarSubModels
        public async Task<ActionResult> Index()
        {
            var carSubModels = db.carSubModels.Include(c => c.carModel);
            return View(await carSubModels.ToListAsync());
        }

        // GET: CarSubModels/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSubModel carSubModel = await db.carSubModels.FindAsync(id);
            if (carSubModel == null)
            {
                return HttpNotFound();
            }
            return View(carSubModel);
        }

        // GET: CarSubModels/Create
        public ActionResult Create()
        {
            ViewBag.modelID = new SelectList(db.carModels, "modelID", "modelName");
            return View();
        }

        // POST: CarSubModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "subModelID,subModelName,subModelDescription,modelID")] CarSubModel carSubModel)
        {
            if (ModelState.IsValid)
            {
                db.carSubModels.Add(carSubModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.modelID = new SelectList(db.carModels, "modelID", "modelName", carSubModel.modelID);
            return View(carSubModel);
        }

        // GET: CarSubModels/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSubModel carSubModel = await db.carSubModels.FindAsync(id);
            if (carSubModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.modelID = new SelectList(db.carModels, "modelID", "modelName", carSubModel.modelID);
            return View(carSubModel);
        }

        // POST: CarSubModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "subModelID,subModelName,subModelDescription,modelID")] CarSubModel carSubModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carSubModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.modelID = new SelectList(db.carModels, "modelID", "modelName", carSubModel.modelID);
            return View(carSubModel);
        }

        // GET: CarSubModels/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSubModel carSubModel = await db.carSubModels.FindAsync(id);
            if (carSubModel == null)
            {
                return HttpNotFound();
            }
            return View(carSubModel);
        }

        // POST: CarSubModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            CarSubModel carSubModel = await db.carSubModels.FindAsync(id);
            db.carSubModels.Remove(carSubModel);
            await db.SaveChangesAsync();
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
