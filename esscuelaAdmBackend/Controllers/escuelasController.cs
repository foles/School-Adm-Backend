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
    public class escuelasController : ApiController
    {
        private escuelaDBEntities db = new escuelaDBEntities();

        // GET: api/escuelas
        public IQueryable<escuela> Getescuela()
        {
            return db.escuela;
        }

        // GET: api/escuelas/5
        [ResponseType(typeof(escuela))]
        public IHttpActionResult Getescuela(int id)
        {
            escuela escuela = db.escuela.Find(id);
            if (escuela == null)
            {
                return NotFound();
            }

            return Ok(escuela);
        }

        // PUT: api/escuelas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putescuela(int id, escuela escuela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != escuela.id)
            {
                return BadRequest();
            }

            db.Entry(escuela).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!escuelaExists(id))
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

        // POST: api/escuelas
        [ResponseType(typeof(escuela))]
        public IHttpActionResult Postescuela(escuela escuela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.escuela.Add(escuela);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = escuela.id }, escuela);
        }

        // DELETE: api/escuelas/5
        [ResponseType(typeof(escuela))]
        public IHttpActionResult Deleteescuela(int id)
        {
            escuela escuela = db.escuela.Find(id);
            if (escuela == null)
            {
                return NotFound();
            }

            db.escuela.Remove(escuela);
            db.SaveChanges();

            return Ok(escuela);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool escuelaExists(int id)
        {
            return db.escuela.Count(e => e.id == id) > 0;
        }
    }
}