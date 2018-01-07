using MovieTimeWebAPI.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;

namespace MovieTimeWebAPI.Controllers
{
    public class ListingsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Listings
        public IEnumerable<Listing> GetListing()
        {


            return db.Listing.ToList();
        }

        // GET: api/Listings/5
        [ResponseType(typeof(Listing))]
        public IHttpActionResult GetListing(int id)
        {
            Listing Listing = db.Listing.Find(id);
            if (Listing == null)
            {
                return NotFound();
            }

            return Ok(Listing);
        }

        // PUT: api/Listings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutListing(int id, Listing Listing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Listing.ListingId)
            {
                return BadRequest();
            }

            db.Entry(Listing).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListingExists(id))
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

        // POST: api/Listings
        [ResponseType(typeof(Listing))]
        public IHttpActionResult PostListing(Listing model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = User.Identity as ClaimsIdentity;
            Claim idenitytClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            ApplicationUser user = db.Users.FirstOrDefault(u => u.Id == idenitytClaim.Value);
            Listing Listing = new Listing();
            Listing.Film = db.Film.Find(model.ListingId);
            Listing.User = user;
            db.Listing.Add(Listing);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ListingExists(Listing.ListingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created("api/Listings", Listing);
        }

        // DELETE: api/Listings/5
        [ResponseType(typeof(Listing))]
        public IHttpActionResult DeleteListing(int id)
        {
            Listing Listing = db.Listing.Find(id);
            if (Listing == null)
            {
                return NotFound();
            }

            db.Listing.Remove(Listing);
            db.SaveChanges();

            return Ok(Listing);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListingExists(int id)
        {
            return db.Listing.Count(e => e.ListingId == id) > 0;
        }
    }
}