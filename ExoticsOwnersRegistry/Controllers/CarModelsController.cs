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

namespace Car_Registry.Controllers
{
    public class CarModelsController : Controller
    {
        private ExoticsOwnersRegistryContext db = new ExoticsOwnersRegistryContext();

        // GET: CarModels
        public async Task<ActionResult> Index()
        {
            var carModels = db.carModels.Include(c => c.carMaker);
            return View(await carModels.ToListAsync());
        }

        // GET: CarModels/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = await db.carModels.FindAsync(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // GET: CarModels/Create
        public ActionResult Create()
        {
            ViewBag.makeID = new SelectList(db.carMakers, "makeID", "makeName");
            return View();
        }

        // POST: CarModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "modelID,modelName,ModelDescription,makeID")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                db.carModels.Add(carModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.makeID = new SelectList(db.carMakers, "makeID", "makeName", carModel.makeID);
            return View(carModel);
        }

        // GET: CarModels/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = await db.carModels.FindAsync(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.makeID = new SelectList(db.carMakers, "makeID", "makeName", carModel.makeID);
            return View(carModel);
        }

        // POST: CarModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "modelID,modelName,ModelDescription,makeID")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.makeID = new SelectList(db.carMakers, "makeID", "makeName", carModel.makeID);
            return View(carModel);
        }

        // GET: CarModels/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = await db.carModels.FindAsync(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // POST: CarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            CarModel carModel = await db.carModels.FindAsync(id);
            db.carModels.Remove(carModel);
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
