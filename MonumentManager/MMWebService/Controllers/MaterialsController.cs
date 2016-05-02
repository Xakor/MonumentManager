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
    public class MaterialsController : ApiController
    {
        private SculptureContext db = new SculptureContext();

        // GET: api/Materials
        public IQueryable<Materials> GetMaterials()
        {
            return db.Materials;
        }

        // GET: api/Materials/5
        [ResponseType(typeof(Materials))]
        public IHttpActionResult GetMaterials(int id)
        {
            Materials materials = db.Materials.Find(id);
            if (materials == null)
            {
                return NotFound();
            }

            return Ok(materials);
        }

        // PUT: api/Materials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaterials(int id, Materials materials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != materials.Material_Id)
            {
                return BadRequest();
            }

            db.Entry(materials).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialsExists(id))
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

        // POST: api/Materials
        [ResponseType(typeof(Materials))]
        public IHttpActionResult PostMaterials(Materials materials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Materials.Add(materials);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = materials.Material_Id }, materials);
        }

        // DELETE: api/Materials/5
        [ResponseType(typeof(Materials))]
        public IHttpActionResult DeleteMaterials(int id)
        {
            Materials materials = db.Materials.Find(id);
            if (materials == null)
            {
                return NotFound();
            }

            db.Materials.Remove(materials);
            db.SaveChanges();

            return Ok(materials);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaterialsExists(int id)
        {
            return db.Materials.Count(e => e.Material_Id == id) > 0;
        }
    }
}