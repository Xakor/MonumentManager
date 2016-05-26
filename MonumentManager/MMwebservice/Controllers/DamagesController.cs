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
    public class DamagesController : ApiController
    {
        private SculptureContext db = new SculptureContext();

        // GET: api/Damages
        public IQueryable<Damages> GetDamages()
        {
            return db.Damages;
        }

        // GET: api/Damages/5
        [ResponseType(typeof(Damages))]
        public IHttpActionResult GetDamages(int id)
        {
            Damages damages = db.Damages.Find(id);
            if (damages == null)
            {
                return NotFound();
            }

            return Ok(damages);
        }

        // PUT: api/Damages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDamages(int id, Damages damages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != damages.Damage_Id)
            {
                return BadRequest();
            }

            db.Entry(damages).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DamagesExists(id))
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

        // POST: api/Damages
        [ResponseType(typeof(Damages))]
        public IHttpActionResult PostDamages(Damages damages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Damages.Add(damages);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = damages.Damage_Id }, damages);
        }

        //post a damage to sculpture
        [Route("api/Damages/AddDamageToSculpture")]
        [HttpPost]
        [ResponseType(typeof(Damages))]
        public IHttpActionResult AddDamageToSculpture(Damages damage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            db.Damages.Add(damage);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DamagesExists(damage.Damage_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = damage.Damage_Id }, damage);
        }


        // DELETE: api/Damages/5
        [ResponseType(typeof(Damages))]
        public IHttpActionResult DeleteDamages(int id)
        {
            Damages damages = db.Damages.Find(id);
            if (damages == null)
            {
                return NotFound();
            }

            db.Damages.Remove(damages);
            db.SaveChanges();

            return Ok(damages);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DamagesExists(int id)
        {
            return db.Damages.Count(e => e.Damage_Id == id) > 0;
        }
    }
}