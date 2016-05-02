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
using MMWebService;

namespace MMWebService.Controllers
{
    public class InspectionsController : ApiController
    {
        private SculptureContext db = new SculptureContext();

        // GET: api/Inspections
        public IQueryable<Inspections> GetInspections()
        {
            return db.Inspections;
        }

        // GET: api/Inspections/5
        [ResponseType(typeof(Inspections))]
        public IHttpActionResult GetInspections(int id)
        {
            Inspections inspections = db.Inspections.Find(id);
            if (inspections == null)
            {
                return NotFound();
            }

            return Ok(inspections);
        }

        // PUT: api/Inspections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInspections(int id, Inspections inspections)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inspections.Inspection_Id)
            {
                return BadRequest();
            }

            db.Entry(inspections).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectionsExists(id))
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

        // POST: api/Inspections
        [ResponseType(typeof(Inspections))]
        public IHttpActionResult PostInspections(Inspections inspections)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inspections.Add(inspections);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = inspections.Inspection_Id }, inspections);
        }

        // DELETE: api/Inspections/5
        [ResponseType(typeof(Inspections))]
        public IHttpActionResult DeleteInspections(int id)
        {
            Inspections inspections = db.Inspections.Find(id);
            if (inspections == null)
            {
                return NotFound();
            }

            db.Inspections.Remove(inspections);
            db.SaveChanges();

            return Ok(inspections);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InspectionsExists(int id)
        {
            return db.Inspections.Count(e => e.Inspection_Id == id) > 0;
        }
    }
}