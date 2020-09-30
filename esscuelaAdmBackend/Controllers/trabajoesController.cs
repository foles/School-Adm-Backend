using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using esscuelaAdmBackend.Models;

namespace esscuelaAdmBackend.Controllers
{
    [EnableCors("*", "*", "*")]
    public class trabajoesController : ApiController
    {
        private escuelaDBEntities db = new escuelaDBEntities();

        // GET: api/trabajoes
        public IQueryable<trabajo> Gettrabajo()
        {
            return db.trabajo;
        }

        // GET: api/trabajoes/5
        [ResponseType(typeof(trabajo))]
        public IHttpActionResult Gettrabajo(int id)
        {
            trabajo trabajo = db.trabajo.Find(id);
            if (trabajo == null)
            {
                return NotFound();
            }

            return Ok(trabajo);
        }

        // PUT: api/trabajoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttrabajo(int id, trabajo trabajo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trabajo.id)
            {
                return BadRequest();
            }

            db.Entry(trabajo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!trabajoExists(id))
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

        // POST: api/trabajoes
        [ResponseType(typeof(trabajo))]
        public IHttpActionResult Posttrabajo(trabajo trabajo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.trabajo.Add(trabajo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trabajo.id }, trabajo);
        }

        // DELETE: api/trabajoes/5
        [ResponseType(typeof(trabajo))]
        public IHttpActionResult Deletetrabajo(int id)
        {
            trabajo trabajo = db.trabajo.Find(id);
            if (trabajo == null)
            {
                return NotFound();
            }

            db.trabajo.Remove(trabajo);
            db.SaveChanges();

            return Ok(trabajo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool trabajoExists(int id)
        {
            return db.trabajo.Count(e => e.id == id) > 0;
        }
    }
}