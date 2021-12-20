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
using EjercicioREST.Models;

namespace EjercicioREST.Controllers
{
    public class DocenteController : ApiController
    {
        private DocentesBDEntities db = new DocentesBDEntities();

        // GET: api/Docente
        public IQueryable<Docente> GetDocente()
        {
            return db.Docente;
        }

        // GET: api/Docente/5
        [ResponseType(typeof(Docente))]
        public IHttpActionResult GetDocente(int id)
        {
            Docente docente = db.Docente.Find(id);
            if (docente == null)
            {
                return NotFound();
            }

            return Ok(docente);
        }

        // PUT: api/Docente/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDocente(int id, Docente docente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != docente.Id)
            {
                return BadRequest();
            }

            db.Entry(docente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocenteExists(id))
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

        // POST: api/Docente
        [ResponseType(typeof(Docente))]
        public IHttpActionResult PostDocente(Docente docente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Docente.Add(docente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = docente.Id }, docente);
        }

        // DELETE: api/Docente/5
        [ResponseType(typeof(Docente))]
        public IHttpActionResult DeleteDocente(int id)
        {
            Docente docente = db.Docente.Find(id);
            if (docente == null)
            {
                return NotFound();
            }

            db.Docente.Remove(docente);
            db.SaveChanges();

            return Ok(docente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DocenteExists(int id)
        {
            return db.Docente.Count(e => e.Id == id) > 0;
        }
    }
}