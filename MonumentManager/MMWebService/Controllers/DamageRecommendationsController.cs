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
    public class DamageRecommendationsController : ApiController
    {
        private SculptureContext db = new SculptureContext();

        // GET: api/DamageRecommendations
        public IQueryable<DamageRecommendation> GetDamageRecommendation()
        {
            return db.DamageRecommendation;
        }

        // GET: api/DamageRecommendations/5
        [ResponseType(typeof(DamageRecommendation))]
        public IHttpActionResult GetDamageRecommendation(int id)
        {
            DamageRecommendation damageRecommendation = db.DamageRecommendation.Find(id);
            if (damageRecommendation == null)
            {
                return NotFound();
            }

            return Ok(damageRecommendation);
        }

        // PUT: api/DamageRecommendations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDamageRecommendation(int id, DamageRecommendation damageRecommendation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != damageRecommendation.CareRecommendation_Id)
            {
                return BadRequest();
            }

            db.Entry(damageRecommendation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DamageRecommendationExists(id))
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

        // POST: api/DamageRecommendations
        [ResponseType(typeof(DamageRecommendation))]
        public IHttpActionResult PostDamageRecommendation(DamageRecommendation damageRecommendation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DamageRecommendation.Add(damageRecommendation);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DamageRecommendationExists(damageRecommendation.CareRecommendation_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = damageRecommendation.CareRecommendation_Id }, damageRecommendation);
        }

        // DELETE: api/DamageRecommendations/5
        [ResponseType(typeof(DamageRecommendation))]
        public IHttpActionResult DeleteDamageRecommendation(int id)
        {
            DamageRecommendation damageRecommendation = db.DamageRecommendation.Find(id);
            if (damageRecommendation == null)
            {
                return NotFound();
            }

            db.DamageRecommendation.Remove(damageRecommendation);
            db.SaveChanges();

            return Ok(damageRecommendation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DamageRecommendationExists(int id)
        {
            return db.DamageRecommendation.Count(e => e.CareRecommendation_Id == id) > 0;
        }
    }
}