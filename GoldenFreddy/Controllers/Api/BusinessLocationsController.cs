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
    public class BusinessLocationsController : ApiController
    {
        private GoldenFreddyDb db = new GoldenFreddyDb();

        // GET: api/BusinessLocations
        public IQueryable<BusinessLocation> GetBusinessLocations()
        {
            return db.BusinessLocations;
        }

        // GET: api/BusinessLocations/5
        [ResponseType(typeof(BusinessLocation))]
        public async Task<IHttpActionResult> GetBusinessLocation(int id)
        {
            BusinessLocation businessLocation = await db.BusinessLocations.FindAsync(id);
            if (businessLocation == null)
            {
                return NotFound();
            }

            return Ok(businessLocation);
        }

        // PUT: api/BusinessLocations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBusinessLocation(int id, BusinessLocation businessLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != businessLocation.Id)
            {
                return BadRequest();
            }

            db.Entry(businessLocation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessLocationExists(id))
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

        // POST: api/BusinessLocations
        [ResponseType(typeof(BusinessLocation))]
        public async Task<IHttpActionResult> PostBusinessLocation(BusinessLocation businessLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BusinessLocations.Add(businessLocation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = businessLocation.Id }, businessLocation);
        }

        // DELETE: api/BusinessLocations/5
        [ResponseType(typeof(BusinessLocation))]
        public async Task<IHttpActionResult> DeleteBusinessLocation(int id)
        {
            BusinessLocation businessLocation = await db.BusinessLocations.FindAsync(id);
            if (businessLocation == null)
            {
                return NotFound();
            }

            db.BusinessLocations.Remove(businessLocation);
            await db.SaveChangesAsync();

            return Ok(businessLocation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BusinessLocationExists(int id)
        {
            return db.BusinessLocations.Count(e => e.Id == id) > 0;
        }
    }
}