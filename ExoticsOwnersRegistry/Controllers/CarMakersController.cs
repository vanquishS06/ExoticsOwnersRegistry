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
    public class CarMakersController : Controller
    {
        private ExoticsOwnersRegistryContext db = new ExoticsOwnersRegistryContext();

        // GET: CarMakers
        public async Task<ActionResult> Index()
        {
            return View(await db.carMakers.ToListAsync());
        }

        // GET: CarMakers/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarMaker carMaker = await db.carMakers.FindAsync(id);
            if (carMaker == null)
            {
                return HttpNotFound();
            }
            return View(carMaker);
        }

        // GET: CarMakers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarMakers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "makeID,makeName,makeHistory")] CarMaker carMaker)
        {
            if (ModelState.IsValid)
            {
                db.carMakers.Add(carMaker);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(carMaker);
        }

        // GET: CarMakers/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarMaker carMaker = await db.carMakers.FindAsync(id);
            if (carMaker == null)
            {
                return HttpNotFound();
            }
            return View(carMaker);
        }

        // POST: CarMakers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "makeID,makeName,makeHistory")] CarMaker carMaker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carMaker).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(carMaker);
        }

        // GET: CarMakers/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarMaker carMaker = await db.carMakers.FindAsync(id);
            if (carMaker == null)
            {
                return HttpNotFound();
            }
            return View(carMaker);
        }

        // POST: CarMakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            CarMaker carMaker = await db.carMakers.FindAsync(id);
            db.carMakers.Remove(carMaker);
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
