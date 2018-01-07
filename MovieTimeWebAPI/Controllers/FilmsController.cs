using MovieTimeWebAPI.Models;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace MovieTimeWebAPI.Controllers
{
    public class FilmsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Films
        public IEnumerable<Film> GetFilm()
        {
            return db.Film.ToList();
        }

        // GET: api/Films/5
        [ResponseType(typeof(Film))]
        public IHttpActionResult GetFilm(int id)
        {
            Film Film = db.Film.Find(id);
            if (Film == null)
            {
                return NotFound();
            }

            return Ok(Film);
        }

        // PUT: api/Films/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFilm(int id, Film model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Film Film = await db.Film.FindAsync(id);

            //db.Entry(Film).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
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

        // POST: api/Films
        [ResponseType(typeof(Film))]
        public IHttpActionResult PostFilm(Film Film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Film.Add(Film);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = Film.FilmId }, Film);
        }

        // DELETE: api/Films/5
        [ResponseType(typeof(Film))]
        public IHttpActionResult DeleteFilm(int id)
        {
            Film Film = db.Film.Find(id);
            if (Film == null)
            {
                return NotFound();
            }

            db.Film.Remove(Film);
            db.SaveChanges();

            return Ok(Film);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FilmExists(int id)
        {
            return db.Film.Count(e => e.FilmId == id) > 0;
        }
    }
}

