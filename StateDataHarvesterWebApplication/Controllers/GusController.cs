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
using DataLayerLibrary;
using DtoLibrary.Gus;
using GusLibrary;

namespace StateDataHarvesterWebApplication.Controllers
{
    public class GusController : ApiController
    {
        private Context db = new Context();

        // GET: api/GusDataDtoes
        public IQueryable<GusDataDto> GetGusDomain()
        {
            return db.GusDomain;
        }

        // GET: api/GusDataDtoes/5
        [ResponseType(typeof(GusDataDto))]
        public IHttpActionResult GetGusDataDto(long id)
        {
            var gusDataDto = db.GusDomain.FirstOrDefault(e => e.Nip == id.ToString() && e.AddedDate == DateTime.Today);
            if (gusDataDto == null)
            {
                gusDataDto = GusApiHelper.DataSearchSubjects(id.ToString());
                db.GusDomain.Add(gusDataDto);
                db.SaveChanges();
                //return NotFound();
            }
            return Ok(gusDataDto);
        }

        // PUT: api/GusDataDtoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGusDataDto(int id, GusDataDto gusDataDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gusDataDto.Id)
            {
                return BadRequest();
            }

            db.Entry(gusDataDto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GusDataDtoExists(id))
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

        // POST: api/GusDataDtoes
        [ResponseType(typeof(GusDataDto))]
        public IHttpActionResult PostGusDataDto(GusDataDto gusDataDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GusDomain.Add(gusDataDto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gusDataDto.Id }, gusDataDto);
        }

        // DELETE: api/GusDataDtoes/5
        [ResponseType(typeof(GusDataDto))]
        public IHttpActionResult DeleteGusDataDto(int id)
        {
            GusDataDto gusDataDto = db.GusDomain.Find(id);
            if (gusDataDto == null)
            {
                return NotFound();
            }

            db.GusDomain.Remove(gusDataDto);
            db.SaveChanges();

            return Ok(gusDataDto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GusDataDtoExists(int id)
        {
            return db.GusDomain.Count(e => e.Id == id) > 0;
        }
    }
}