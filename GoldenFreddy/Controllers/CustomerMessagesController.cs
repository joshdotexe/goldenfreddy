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
    public class CustomerMessagesController : Controller
    {
        private GoldenFreddyDb db = new GoldenFreddyDb();

        // GET: CustomerMessages
        public async Task<ActionResult> Index()
        {
            var customerMessages = db.CustomerMessages.Include(c => c.FromCustomer).Include(c => c.ToCustomer);
            return View(await customerMessages.ToListAsync());
        }

        // GET: CustomerMessages/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerMessage customerMessage = await db.CustomerMessages.FindAsync(id);
            if (customerMessage == null)
            {
                return HttpNotFound();
            }
            return View(customerMessage);
        }

        // GET: CustomerMessages/Create
        public ActionResult Create()
        {
            ViewBag.FromCustomerId = new SelectList(db.Customers, "Id", "FirstName");
            ViewBag.ToCustomerId = new SelectList(db.Customers, "Id", "FirstName");
            return View();
        }

        // POST: CustomerMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Created,ToCustomerId,FromCustomerId,Body,Status")] CustomerMessage customerMessage)
        {
            if (ModelState.IsValid)
            {
                db.CustomerMessages.Add(customerMessage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FromCustomerId = new SelectList(db.Customers, "Id", "FirstName", customerMessage.FromCustomerId);
            ViewBag.ToCustomerId = new SelectList(db.Customers, "Id", "FirstName", customerMessage.ToCustomerId);
            return View(customerMessage);
        }

        // GET: CustomerMessages/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerMessage customerMessage = await db.CustomerMessages.FindAsync(id);
            if (customerMessage == null)
            {
                return HttpNotFound();
            }
            ViewBag.FromCustomerId = new SelectList(db.Customers, "Id", "FirstName", customerMessage.FromCustomerId);
            ViewBag.ToCustomerId = new SelectList(db.Customers, "Id", "FirstName", customerMessage.ToCustomerId);
            return View(customerMessage);
        }

        // POST: CustomerMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Created,ToCustomerId,FromCustomerId,Body,Status")] CustomerMessage customerMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerMessage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FromCustomerId = new SelectList(db.Customers, "Id", "FirstName", customerMessage.FromCustomerId);
            ViewBag.ToCustomerId = new SelectList(db.Customers, "Id", "FirstName", customerMessage.ToCustomerId);
            return View(customerMessage);
        }

        // GET: CustomerMessages/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerMessage customerMessage = await db.CustomerMessages.FindAsync(id);
            if (customerMessage == null)
            {
                return HttpNotFound();
            }
            return View(customerMessage);
        }

        // POST: CustomerMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CustomerMessage customerMessage = await db.CustomerMessages.FindAsync(id);
            db.CustomerMessages.Remove(customerMessage);
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
