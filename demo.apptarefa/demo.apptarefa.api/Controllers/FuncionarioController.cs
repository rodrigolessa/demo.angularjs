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
using demo.apptarefa.domain.Models;

namespace demo.apptarefa.api.Controllers
{
    public class FuncionarioController : ApiController
    {
        private ProvaDeConceitoContext db = new ProvaDeConceitoContext();

        // GET api/Funcionario
        public IQueryable<Funcionario> GetFuncionarios()
        {
            return db.Funcionarios;
        }

        // GET api/Funcionario/5
        [ResponseType(typeof(Funcionario))]
        public IHttpActionResult GetFuncionario(int id)
        {
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return Ok(funcionario);
        }

        // PUT api/Funcionario/5
        public IHttpActionResult PutFuncionario(int id, Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != funcionario.Id)
            {
                return BadRequest();
            }

            db.Entry(funcionario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(id))
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

        // POST api/Funcionario
        [ResponseType(typeof(Funcionario))]
        public IHttpActionResult PostFuncionario(Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Funcionarios.Add(funcionario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = funcionario.Id }, funcionario);
        }

        // DELETE api/Funcionario/5
        [ResponseType(typeof(Funcionario))]
        public IHttpActionResult DeleteFuncionario(int id)
        {
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            db.Funcionarios.Remove(funcionario);
            db.SaveChanges();

            return Ok(funcionario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FuncionarioExists(int id)
        {
            return db.Funcionarios.Count(e => e.Id == id) > 0;
        }
    }
}