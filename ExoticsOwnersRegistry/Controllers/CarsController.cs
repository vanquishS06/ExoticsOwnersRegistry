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
    public class CarsController : Controller
    {
        private ExoticsOwnersRegistryContext db = new ExoticsOwnersRegistryContext();

        // GET: Cars
        public async Task<ActionResult> Index()
        {
            var cars = db.cars.Include(c => c.carDetails)
                              .Include(c => c.carMaker)
                              .Include(c => c.carModel)
                              .Include(c => c.carSubModel);

            return View(await cars.ToListAsync());
        }

        // Display cars by Vin
        public ActionResult DisplayCarsByVin()
        {
            //TODO code here
            return View();
        }

        // Display car details 
        public async Task<ActionResult> Show(long? id)
        {
            CarDetails carDetails = await db.carDetails.FindAsync(id);

            return View(carDetails);
        }


        // GET: Cars/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = await db.cars.FindAsync(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        // Display the form
        // The Authorize attribute will send the user to the Account controller for login
        //[Authorize]
        public ActionResult Create()
        {
            ViewBag.carID = new SelectList(db.carDetails, "carID");//, "originalExteriorColor");
            ViewBag.makeID = new SelectList(db.carMakers, "makeID", "makeName");
            ViewBag.modelID = new SelectList(db.carModels, "modelID", "modelName");
            ViewBag.subModelID = new SelectList(db.carSubModels, "subModelID", "subModelName");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // Accept the input
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "carID,VIN,makeID,modelID,subModelID,approvalStatus,bHideCar,showCaseCarPicture,TimeStamp")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.cars.Add(car);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            //ViewBag.carID = new SelectList((db.carDetails));
            //ViewBag.carID = new SelectList(db.carDetails, "carID", "originalExteriorColor", car.carID);
            ViewBag.makeID = new SelectList(db.carMakers, "makeID", "makeName", car.makeID);
            ViewBag.modelID = new SelectList(db.carModels, "modelID", "modelName", car.modelID);
            ViewBag.subModelID = new SelectList(db.carSubModels, "subModelID", "subModelName", car.subModelID);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = await db.cars.FindAsync(id);
            if (car == null)
            {
                return HttpNotFound();
            }
//            ViewBag.carID = new SelectList((db.carDetails));
            ViewBag.makeID = new SelectList(db.carMakers, "makeID", "makeName", car.makeID);
            ViewBag.modelID = new SelectList(db.carModels, "modelID", "modelName", car.modelID);
            ViewBag.subModelID = new SelectList(db.carSubModels, "subModelID", "subModelName", car.subModelID);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "carID,VIN,makeID,modelID,subModelID,approvalStatus,bHideCar,showCaseCarPicture,TimeStamp")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
//            ViewBag.carID = new SelectList(db.carDetails, "carID", "originalExteriorColor", car.carID);
            ViewBag.makeID = new SelectList(db.carMakers, "makeID", "makeName", car.makeID);
            ViewBag.modelID = new SelectList(db.carModels, "modelID", "modelName", car.modelID);
            ViewBag.subModelID = new SelectList(db.carSubModels, "subModelID", "subModelName", car.subModelID);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = await db.cars.FindAsync(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Car car = await db.cars.FindAsync(id);
            db.cars.Remove(car);
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
