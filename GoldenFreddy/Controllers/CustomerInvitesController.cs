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
    public class CustomerInvitesController : Controller
    {
        private GoldenFreddyDb db = new GoldenFreddyDb();

        // GET: CustomerInvites
        public async Task<ActionResult> Index()
        {
            var customerInvites = db.CustomerInvites.Include(c => c.FromCustomer).Include(c => c.ToCustomer);
            return View(await customerInvites.ToListAsync());
        }

        // GET: CustomerInvites/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInvite customerInvite = await db.CustomerInvites.FindAsync(id);
            if (customerInvite == null)
            {
                return HttpNotFound();
            }
            return View(customerInvite);
        }

        // GET: CustomerInvites/Create
        public ActionResult Create()
        {
            ViewBag.FromCustomerId = new SelectList(db.Customers, "Id", "FirstName");
            ViewBag.ToCustomerId = new SelectList(db.Customers, "Id", "FirstName");
            return View();
        }

        // POST: CustomerInvites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Created,ToCustomerId,FromCustomerId,Status,Reason")] CustomerInvite customerInvite)
        {
            if (ModelState.IsValid)
            {
                db.CustomerInvites.Add(customerInvite);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FromCustomerId = new SelectList(db.Customers, "Id", "FirstName", customerInvite.FromCustomerId);
            ViewBag.ToCustomerId = new SelectList(db.Customers, "Id", "FirstName", customerInvite.ToCustomerId);
            return View(customerInvite);
        }

        // GET: CustomerInvites/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInvite customerInvite = await db.CustomerInvites.FindAsync(id);
            if (customerInvite == null)
            {
                return HttpNotFound();
            }
            ViewBag.FromCustomerId = new SelectList(db.Customers, "Id", "FirstName", customerInvite.FromCustomerId);
            ViewBag.ToCustomerId = new SelectList(db.Customers, "Id", "FirstName", customerInvite.ToCustomerId);
            return View(customerInvite);
        }

        // POST: CustomerInvites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Created,ToCustomerId,FromCustomerId,Status,Reason")] CustomerInvite customerInvite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerInvite).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FromCustomerId = new SelectList(db.Customers, "Id", "FirstName", customerInvite.FromCustomerId);
            ViewBag.ToCustomerId = new SelectList(db.Customers, "Id", "FirstName", customerInvite.ToCustomerId);
            return View(customerInvite);
        }

        // GET: CustomerInvites/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInvite customerInvite = await db.CustomerInvites.FindAsync(id);
            if (customerInvite == null)
            {
                return HttpNotFound();
            }
            return View(customerInvite);
        }

        // POST: CustomerInvites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CustomerInvite customerInvite = await db.CustomerInvites.FindAsync(id);
            db.CustomerInvites.Remove(customerInvite);
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
