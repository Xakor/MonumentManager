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
using MMWebService;

namespace MMWebService.Controllers
{
    public class SculpturesController : ApiController
    {
        private SculptureContext db = new SculptureContext();

        // GET: api/Sculptures
        public IQueryable<Sculptures> GetSculptures()
        {
            return db.Sculptures;
        }

        // GET: api/Sculptures/5
        [ResponseType(typeof(Sculptures))]
        public IHttpActionResult GetSculptures(int id)
        {
            Sculptures sculptures = db.Sculptures.Find(id);
            if (sculptures == null)
            {
                return NotFound();
            }

            return Ok(sculptures);
        }

        // PUT: api/Sculptures/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSculptures(int id, Sculptures sculptures)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sculptures.Sculpture_Id)
            {
                return BadRequest();
            }

            db.Entry(sculptures).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SculpturesExists(id))
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

        // POST: api/Sculptures
        [ResponseType(typeof(Sculptures))]
        public IHttpActionResult PostSculptures(Sculptures sculptures)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sculptures.Add(sculptures);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sculptures.Sculpture_Id }, sculptures);
        }

        // DELETE: api/Sculptures/5
        [ResponseType(typeof(Sculptures))]
        public IHttpActionResult DeleteSculptures(int id)
        {
            Sculptures sculptures = db.Sculptures.Find(id);
            if (sculptures == null)
            {
                return NotFound();
            }

            db.Sculptures.Remove(sculptures);
            db.SaveChanges();

            return Ok(sculptures);
        }

        // Insert with many to many 

        // POST: api/Sculptures/SculptureAddTypes
        [Route("api/Sculptures/SculptureAddTypes/{sculptureId:int}/{typeId:int}")]
        // [HttpPost]

        [HttpGet]
        [ResponseType(typeof (Sculptures))]
        public async Task<IHttpActionResult> GetAddTypeToSculpture(int sculptureId, int typeId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Sculptures sculptureFound = db.Sculptures.FirstOrDefault(s => s.Sculpture_Id == sculptureId);
            Types typeFound = db.Types.FirstOrDefault(t => t.Type_Id == typeId);

            sculptureFound.Types.Add(typeFound);

            //db.Hotels.Remove(hotelFound);
            //try
            //{
            //    await db.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (HotelExists(hotel.Hotel_No))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            //db.Hotels.Add(hotel);
            //db.Hotels.Add(hotel);

            db.Entry(sculptureFound).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SculpturesExists(sculptureFound.Sculpture_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }


            return CreatedAtRoute("DefaultApi", new { id = sculptureFound.Sculpture_Id }, sculptureFound);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SculpturesExists(int id)
        {
            return db.Sculptures.Count(e => e.Sculpture_Id == id) > 0;
        }
    }
}