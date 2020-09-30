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

    public class estudiantesController : ApiController
    {
        private escuelaDBEntities db = new escuelaDBEntities();

        // GET: api/estudiantes
        public IQueryable<estudiante> Getestudiante()
        {
            return db.estudiante;
        }

        // GET: api/estudiantes/5
        [ResponseType(typeof(estudiante))]
        public IHttpActionResult Getestudiante(int id)
        {
            estudiante estudiante = db.estudiante.Find(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return Ok(estudiante);
        }

        // PUT: api/estudiantes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putestudiante(int id, estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estudiante.id)
            {
                return BadRequest();
            }

            db.Entry(estudiante).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!estudianteExists(id))
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

        // POST: api/estudiantes
        [ResponseType(typeof(estudiante))]
        public IHttpActionResult Postestudiante(estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.estudiante.Add(estudiante);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = estudiante.id }, estudiante);
        }

        // DELETE: api/estudiantes/5
        [ResponseType(typeof(estudiante))]
        public IHttpActionResult Deleteestudiante(int id)
        {
            estudiante estudiante = db.estudiante.Find(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            db.estudiante.Remove(estudiante);
            db.SaveChanges();

            return Ok(estudiante);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool estudianteExists(int id)
        {
            return db.estudiante.Count(e => e.id == id) > 0;
        }
    }
}