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
    public class CarDetailsController : Controller
    {
        private ExoticsOwnersRegistryContext db = new ExoticsOwnersRegistryContext();

        // GET: CarDetails
        public async Task<ActionResult> Index()
        {
            var carDetails = db.carDetails.Include(c => c.car);
            return View(await carDetails.ToListAsync());
        }

        // GET: CarDetails/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarDetails carDetails = await db.carDetails.FindAsync(id);
            if (carDetails == null)
            {
                return HttpNotFound();
            }
            return View(carDetails);
        }

        // GET: CarDetails/Create
        public ActionResult Create()
        {
            ViewBag.carID = new SelectList(db.cars, "carID", "VIN");
            return View();
        }

        // POST: CarDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "carID,originalFuelSystem,currentFuelSystem,originalExteriorColor,originalInteriorColor,currentExteriorColor,currentInteriorColor,modelYear,productionDate,deliveryCountry,deliveryDealership,currentCountryLocation,currentRegionalLocation")] CarDetails carDetails)
        {
            if (ModelState.IsValid)
            {
                db.carDetails.Add(carDetails);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.carID = new SelectList(db.cars, "carID", "VIN", carDetails.carID);
            return View(carDetails);
        }

        // GET: CarDetails/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarDetails carDetails = await db.carDetails.FindAsync(id);
            if (carDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.carID = new SelectList(db.cars, "carID", "VIN", carDetails.carID);
            return View(carDetails);
        }

        // POST: CarDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "carID,originalFuelSystem,currentFuelSystem,originalExteriorColor,originalInteriorColor,currentExteriorColor,currentInteriorColor,modelYear,productionDate,deliveryCountry,deliveryDealership,currentCountryLocation,currentRegionalLocation")] CarDetails carDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carDetails).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.carID = new SelectList(db.cars, "carID", "VIN", carDetails.carID);
            return View(carDetails);
        }

        // GET: CarDetails/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarDetails carDetails = await db.carDetails.FindAsync(id);
            if (carDetails == null)
            {
                return HttpNotFound();
            }
            return View(carDetails);
        }

        // POST: CarDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            CarDetails carDetails = await db.carDetails.FindAsync(id);
            db.carDetails.Remove(carDetails);
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
