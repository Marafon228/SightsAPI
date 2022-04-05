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
    public class SightsCommentsController : ApiController
    {
        private ADO db = new ADO();

        // GET: api/SightsComments
        public IQueryable<SightsComment> GetSightsComment()
        {
            return db.SightsComment;
        }

        // GET: api/SightsComments/5
        [ResponseType(typeof(SightsComment))]
        public IHttpActionResult GetSightsComment(int id)
        {
            SightsComment sightsComment = db.SightsComment.Find(id);
            if (sightsComment == null)
            {
                return NotFound();
            }

            return Ok(sightsComment);
        }

        // PUT: api/SightsComments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSightsComment(int id, SightsComment sightsComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sightsComment.Id)
            {
                return BadRequest();
            }

            db.Entry(sightsComment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SightsCommentExists(id))
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

        // POST: api/SightsComments
        [ResponseType(typeof(SightsComment))]
        public IHttpActionResult PostSightsComment(SightsComment sightsComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SightsComment.Add(sightsComment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sightsComment.Id }, sightsComment);
        }

        // DELETE: api/SightsComments/5
        [ResponseType(typeof(SightsComment))]
        public IHttpActionResult DeleteSightsComment(int id)
        {
            SightsComment sightsComment = db.SightsComment.Find(id);
            if (sightsComment == null)
            {
                return NotFound();
            }

            db.SightsComment.Remove(sightsComment);
            db.SaveChanges();

            return Ok(sightsComment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SightsCommentExists(int id)
        {
            return db.SightsComment.Count(e => e.Id == id) > 0;
        }
    }
}