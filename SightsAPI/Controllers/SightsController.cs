using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SightsAPI.Models;
using SightsAPI.Models.Json;

namespace SightsAPI.Controllers
{
    public class SightsController : ApiController
    {
        private ADO db = new ADO();

        // GET: api/Sights
        [ActionName("Sights")]
        [ResponseType(typeof(ResponseSights))]
        public IHttpActionResult GetSights()
        {
            return Ok(db.Sights.ToList().ConvertAll(p=> new ResponseSights(p)));
        }

        // GET: api/Sights/5
        [ResponseType(typeof(Sights))]
        public IHttpActionResult GetSights(int id)
        {
            Sights sights = db.Sights.Find(id);
            if (sights == null)
            {
                return NotFound();
            }

            return Ok(sights);
        }

        // PUT: api/Sights/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSights(int id, Sights sights)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sights.Id)
            {
                return BadRequest();
            }

            db.Entry(sights).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SightsExists(id))
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

        // POST: api/Sights
        [ResponseType(typeof(Sights))]
        public IHttpActionResult PostSights(Sights sights)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sights.Add(sights);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sights.Id }, sights);
        }

        // DELETE: api/Sights/5
        [ResponseType(typeof(Sights))]
        public IHttpActionResult DeleteSights(int id)
        {
            Sights sights = db.Sights.Find(id);
            if (sights == null)
            {
                return NotFound();
            }

            db.Sights.Remove(sights);
            db.SaveChanges();

            return Ok(sights);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SightsExists(int id)
        {
            return db.Sights.Count(e => e.Id == id) > 0;
        }
    }
}