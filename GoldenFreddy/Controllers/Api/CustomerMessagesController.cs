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
    public class CustomerMessagesController : ApiController
    {
        private GoldenFreddyDb db = new GoldenFreddyDb();

        // GET: api/CustomerMessages
        public IQueryable<CustomerMessage> GetCustomerMessages()
        {
            return db.CustomerMessages;
        }

        // GET: api/CustomerMessages/5
        [ResponseType(typeof(CustomerMessage))]
        public async Task<IHttpActionResult> GetCustomerMessage(int id)
        {
            CustomerMessage customerMessage = await db.CustomerMessages.FindAsync(id);
            if (customerMessage == null)
            {
                return NotFound();
            }

            return Ok(customerMessage);
        }

        // PUT: api/CustomerMessages/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomerMessage(int id, CustomerMessage customerMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerMessage.Id)
            {
                return BadRequest();
            }

            db.Entry(customerMessage).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerMessageExists(id))
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

        // POST: api/CustomerMessages
        [ResponseType(typeof(CustomerMessage))]
        public async Task<IHttpActionResult> PostCustomerMessage(CustomerMessage customerMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerMessages.Add(customerMessage);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = customerMessage.Id }, customerMessage);
        }

        // DELETE: api/CustomerMessages/5
        [ResponseType(typeof(CustomerMessage))]
        public async Task<IHttpActionResult> DeleteCustomerMessage(int id)
        {
            CustomerMessage customerMessage = await db.CustomerMessages.FindAsync(id);
            if (customerMessage == null)
            {
                return NotFound();
            }

            db.CustomerMessages.Remove(customerMessage);
            await db.SaveChangesAsync();

            return Ok(customerMessage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerMessageExists(int id)
        {
            return db.CustomerMessages.Count(e => e.Id == id) > 0;
        }
    }
}