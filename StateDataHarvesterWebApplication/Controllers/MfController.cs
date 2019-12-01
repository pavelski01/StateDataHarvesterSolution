using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using DataLayerLibrary;
using DtoLibrary.Mf;
using MfLibrary;

namespace StateDataHarvesterWebApplication.Controllers
{
    public class MfController : ApiController
    {
        private Context db = new Context();

        // GET: api/MfSubjectDtoes
        public IQueryable<MfSubjectDto> GetMfDomain()
        {
            return db.MfDomain;
        }

        // GET: api/MfSubjectDtoes/5
        [ResponseType(typeof(MfSubjectDto))]
        public IHttpActionResult GetMfSubjectDto(long id)
        {
            var mfSubjectDto = db.MfDomain.FirstOrDefault(e => e.Nip == id.ToString() && e.AddedDate == DateTime.Today);
            if (mfSubjectDto == null)
            {
                mfSubjectDto = MfApiHelper.SearchNip(id.ToString());
                db.MfDomain.Add(mfSubjectDto);
                db.SaveChanges();
                //return NotFound();
            }
            return Ok(mfSubjectDto);
        }

        // PUT: api/MfSubjectDtoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMfSubjectDto(int id, MfSubjectDto mfSubjectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mfSubjectDto.Id)
            {
                return BadRequest();
            }

            db.Entry(mfSubjectDto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MfSubjectDtoExists(id))
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

        // POST: api/MfSubjectDtoes
        [ResponseType(typeof(MfSubjectDto))]
        public IHttpActionResult PostMfSubjectDto(MfSubjectDto mfSubjectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MfDomain.Add(mfSubjectDto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mfSubjectDto.Id }, mfSubjectDto);
        }

        // DELETE: api/MfSubjectDtoes/5
        [ResponseType(typeof(MfSubjectDto))]
        public IHttpActionResult DeleteMfSubjectDto(int id)
        {
            MfSubjectDto mfSubjectDto = db.MfDomain.Find(id);
            if (mfSubjectDto == null)
            {
                return NotFound();
            }

            db.MfDomain.Remove(mfSubjectDto);
            db.SaveChanges();

            return Ok(mfSubjectDto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MfSubjectDtoExists(int id)
        {
            return db.MfDomain.Count(e => e.Id == id) > 0;
        }
    }
}