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

namespace SightsAPI.Controllers
{
    public class HotelsReservationsController : ApiController
    {
        private ADO db = new ADO();




        [ActionName("getHotelReservation")]

        public IHttpActionResult GetResponseHotels(int hotelId)
        {

            var hotelsReservations = db.HotelsReservation.ToList().Where(p => p.HotelsId == hotelId).ToList();
            return Ok(hotelsReservations);
        }







        /*// GET: api/HotelsReservations
        public IQueryable<HotelsReservation> GetHotelsReservation()
        {
            return db.HotelsReservation;
        }

        // GET: api/HotelsReservations/5
        [ResponseType(typeof(HotelsReservation))]
        public IHttpActionResult GetHotelsReservation(int id)
        {
            HotelsReservation hotelsReservation = db.HotelsReservation.Find(id);
            if (hotelsReservation == null)
            {
                return NotFound();
            }

            return Ok(hotelsReservation);
        }*/

       /* // PUT: api/HotelsReservations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHotelsReservation(int id, HotelsReservation hotelsReservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotelsReservation.Id)
            {
                return BadRequest();
            }

            db.Entry(hotelsReservation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelsReservationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }*/

        /*// POST: api/HotelsReservations
        [ResponseType(typeof(HotelsReservation))]
        public IHttpActionResult PostHotelsReservation(HotelsReservation hotelsReservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HotelsReservation.Add(hotelsReservation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hotelsReservation.Id }, hotelsReservation);
        }*/







        [ActionName("PostReservationHotel")]
        [ResponseType(typeof(HotelsReservation))]
        public IHttpActionResult PostHotelComment(HotelsReservation hotelsReservation)
        {
            hotelsReservation.CreationDate = DateTime.Now;



            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            db.HotelsReservation.Add(hotelsReservation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hotelsReservation.Id }, hotelsReservation);
        }









       /* // DELETE: api/HotelsReservations/5
        [ResponseType(typeof(HotelsReservation))]
        public IHttpActionResult DeleteHotelsReservation(int id)
        {
            HotelsReservation hotelsReservation = db.HotelsReservation.Find(id);
            if (hotelsReservation == null)
            {
                return NotFound();
            }

            db.HotelsReservation.Remove(hotelsReservation);
            db.SaveChanges();

            return Ok(hotelsReservation);
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HotelsReservationExists(int id)
        {
            return db.HotelsReservation.Count(e => e.Id == id) > 0;
        }
    }
}