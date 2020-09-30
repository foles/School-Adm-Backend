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
    public class materiasController : ApiController
    {
        private escuelaDBEntities db = new escuelaDBEntities();

        // GET: api/materias
        public IQueryable<materia> Getmateria()
        {
            return db.materia;
        }

        // GET: api/materias/5
        [ResponseType(typeof(materia))]
        public IHttpActionResult Getmateria(int id)
        {
            materia materia = db.materia.Find(id);
            if (materia == null)
            {
                return NotFound();
            }

            return Ok(materia);
        }

        // PUT: api/materias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmateria(int id, materia materia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != materia.id)
            {
                return BadRequest();
            }

            db.Entry(materia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!materiaExists(id))
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

        // POST: api/materias
        [ResponseType(typeof(materia))]
        public IHttpActionResult Postmateria(materia materia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.materia.Add(materia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = materia.id }, materia);
        }

        // DELETE: api/materias/5
        [ResponseType(typeof(materia))]
        public IHttpActionResult Deletemateria(int id)
        {
            materia materia = db.materia.Find(id);
            if (materia == null)
            {
                return NotFound();
            }

            db.materia.Remove(materia);
            db.SaveChanges();

            return Ok(materia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool materiaExists(int id)
        {
            return db.materia.Count(e => e.id == id) > 0;
        }
    }
}