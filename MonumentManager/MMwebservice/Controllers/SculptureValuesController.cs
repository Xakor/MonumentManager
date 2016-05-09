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
using MMwebservice;

namespace MMwebservice.Controllers
{
    public class SculptureValuesController : ApiController
    {
        private SculptureContext db = new SculptureContext();

        // GET: api/SculptureValues
        public IQueryable<SculptureValues> GetSculptureValues()
        {
            return db.SculptureValues;
        }

        // GET: api/SculptureValues/5
        [ResponseType(typeof(SculptureValues))]
        public IHttpActionResult GetSculptureValues(int id)
        {
            SculptureValues sculptureValues = db.SculptureValues.Find(id);
            if (sculptureValues == null)
            {
                return NotFound();
            }

            return Ok(sculptureValues);
        }

        // PUT: api/SculptureValues/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSculptureValues(int id, SculptureValues sculptureValues)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sculptureValues.Value_Id)
            {
                return BadRequest();
            }

            db.Entry(sculptureValues).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SculptureValuesExists(id))
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

        // POST: api/SculptureValues
        [ResponseType(typeof(SculptureValues))]
        public IHttpActionResult PostSculptureValues(SculptureValues sculptureValues)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SculptureValues.Add(sculptureValues);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sculptureValues.Value_Id }, sculptureValues);
        }

        // DELETE: api/SculptureValues/5
        [ResponseType(typeof(SculptureValues))]
        public IHttpActionResult DeleteSculptureValues(int id)
        {
            SculptureValues sculptureValues = db.SculptureValues.Find(id);
            if (sculptureValues == null)
            {
                return NotFound();
            }

            db.SculptureValues.Remove(sculptureValues);
            db.SaveChanges();

            return Ok(sculptureValues);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SculptureValuesExists(int id)
        {
            return db.SculptureValues.Count(e => e.Value_Id == id) > 0;
        }
    }
}