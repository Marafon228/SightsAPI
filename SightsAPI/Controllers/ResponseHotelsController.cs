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
    public class ResponseHotelsController : ApiController
    {
        private ADO db = new ADO();



        [ActionName("getHotelComments")]

        public IHttpActionResult GetResponseHotels(int hotelId)
        {
            
            var hotelsReservations = db.HotelsReservation.ToList().Where(p => p.HotelsId == hotelId).ToList();
            return Ok(hotelsReservations);
        }





        // GET: api/ResponseHotels
        public IQueryable<ResponseHotel> GetResponseHotels()
        {
            return db.ResponseHotels;
        }

        // GET: api/ResponseHotels/5
        [ResponseType(typeof(ResponseHotel))]
        public IHttpActionResult GetResponseHotel(int id)
        {
            ResponseHotel responseHotel = db.ResponseHotels.Find(id);
            if (responseHotel == null)
            {
                return NotFound();
            }

            return Ok(responseHotel);
        }

        // PUT: api/ResponseHotels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResponseHotel(int id, ResponseHotel responseHotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != responseHotel.Id)
            {
                return BadRequest();
            }

            db.Entry(responseHotel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResponseHotelExists(id))
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




        [ActionName("PostHotelComments")]
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






        // POST: api/ResponseHotels
        [ResponseType(typeof(ResponseHotel))]
        public IHttpActionResult PostResponseHotel(ResponseHotel responseHotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ResponseHotels.Add(responseHotel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = responseHotel.Id }, responseHotel);
        }

        // DELETE: api/ResponseHotels/5
        [ResponseType(typeof(ResponseHotel))]
        public IHttpActionResult DeleteResponseHotel(int id)
        {
            ResponseHotel responseHotel = db.ResponseHotels.Find(id);
            if (responseHotel == null)
            {
                return NotFound();
            }

            db.ResponseHotels.Remove(responseHotel);
            db.SaveChanges();

            return Ok(responseHotel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResponseHotelExists(int id)
        {
            return db.ResponseHotels.Count(e => e.Id == id) > 0;
        }
    }
}