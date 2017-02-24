using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoldenFreddy.Models;

namespace GoldenFreddy.Controllers
{
    public class BusinessLocationsController : AppController
    {
        private GoldenFreddyDb db = new GoldenFreddyDb();

        // GET: BusinessLocations
        public async Task<ActionResult> Index()
        {
            var businessLocations = db.BusinessLocations.Include(b => b.Business);
            return View(await businessLocations.ToListAsync());
        }

        // GET: BusinessLocations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessLocation businessLocation = await db.BusinessLocations.FindAsync(id);
            if (businessLocation == null)
            {
                return HttpNotFound();
            }
            return View(businessLocation);
        }

        // GET: BusinessLocations/Create
        public ActionResult Create()
        {
            ViewBag.BusinessId = new SelectList(db.Businesses, "Id", "Name");
            return View();
        }

        // POST: BusinessLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Created,BusinessId,Latitude,Longitude,Address1,Address2,City,StateCode,ZipCode,Phone")] BusinessLocation businessLocation)
        {
            if (ModelState.IsValid)
            {
                db.BusinessLocations.Add(businessLocation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BusinessId = new SelectList(db.Businesses, "Id", "Name", businessLocation.BusinessId);
            return View(businessLocation);
        }

        // GET: BusinessLocations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessLocation businessLocation = await db.BusinessLocations.FindAsync(id);
            if (businessLocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusinessId = new SelectList(db.Businesses, "Id", "Name", businessLocation.BusinessId);
            return View(businessLocation);
        }

        // POST: BusinessLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Created,BusinessId,Latitude,Longitude,Address1,Address2,City,StateCode,ZipCode,Phone")] BusinessLocation businessLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businessLocation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BusinessId = new SelectList(db.Businesses, "Id", "Name", businessLocation.BusinessId);
            return View(businessLocation);
        }

        // GET: BusinessLocations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessLocation businessLocation = await db.BusinessLocations.FindAsync(id);
            if (businessLocation == null)
            {
                return HttpNotFound();
            }
            return View(businessLocation);
        }

        // POST: BusinessLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BusinessLocation businessLocation = await db.BusinessLocations.FindAsync(id);
            db.BusinessLocations.Remove(businessLocation);
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
