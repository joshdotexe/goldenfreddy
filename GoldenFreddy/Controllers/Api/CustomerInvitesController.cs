using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GoldenFreddy.Models;

namespace GoldenFreddy.Controllers.Api
{
    public class CustomerInvitesController : ApiController
    {
        private GoldenFreddyDb db = new GoldenFreddyDb();

        // GET: api/CustomerInvites
        public IQueryable<CustomerInvite> GetCustomerInvites()
        {
            return db.CustomerInvites;
        }

        // GET: api/CustomerInvites/5
        [ResponseType(typeof(CustomerInvite))]
        public async Task<IHttpActionResult> GetCustomerInvite(int id)
        {
            CustomerInvite customerInvite = await db.CustomerInvites.FindAsync(id);
            if (customerInvite == null)
            {
                return NotFound();
            }

            return Ok(customerInvite);
        }

        // PUT: api/CustomerInvites/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomerInvite(int id, CustomerInvite customerInvite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerInvite.Id)
            {
                return BadRequest();
            }

            db.Entry(customerInvite).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerInviteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CustomerInvites
        [ResponseType(typeof(CustomerInvite))]
        public async Task<IHttpActionResult> PostCustomerInvite(CustomerInvite customerInvite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerInvites.Add(customerInvite);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = customerInvite.Id }, customerInvite);
        }

        // DELETE: api/CustomerInvites/5
        [ResponseType(typeof(CustomerInvite))]
        public async Task<IHttpActionResult> DeleteCustomerInvite(int id)
        {
            CustomerInvite customerInvite = await db.CustomerInvites.FindAsync(id);
            if (customerInvite == null)
            {
                return NotFound();
            }

            db.CustomerInvites.Remove(customerInvite);
            await db.SaveChangesAsync();

            return Ok(customerInvite);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerInviteExists(int id)
        {
            return db.CustomerInvites.Count(e => e.Id == id) > 0;
        }
    }
}