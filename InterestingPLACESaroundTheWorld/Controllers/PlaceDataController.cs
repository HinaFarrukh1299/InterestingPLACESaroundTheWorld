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
using InterestingPLACESaroundTheWorld.Models;
using System.Diagnostics;



namespace InterestingPLACESaroundTheWorld.Controllers
{
    public class PlaceDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PlaceData/ListPlaces
        [HttpGet]
        public IEnumerable<PlaceDto> ListPlaces()
        {
            List<Place>Places = db.Places.ToList();
            List<PlaceDto> PlaceDtos = new List<PlaceDto>();


            Places.ForEach(a => PlaceDtos.Add(new PlaceDto()
            {
                PlaceId = a.PlaceId,
                PlaceName = a.PlaceName,
                PlaceDescription = a.PlaceDescription,

                DateOfCreation = a.DateOfCreation,
                Country = a.Origin.Country
            }));
            return PlaceDtos;
        }

        // GET: api/PlaceData/FindPlace/5
        [ResponseType(typeof(Place))]
        [HttpGet]
        public IHttpActionResult FindPlace(int id)
        {
            Place Place = db.Places.Find(id);
            PlaceDto PlaceDto = new PlaceDto()
            {
                PlaceId = Place.PlaceId,
                PlaceName = Place.PlaceName,
                PlaceDescription = Place.PlaceDescription,

                DateOfCreation = Place.DateOfCreation,
                Country = Place.Origin.Country

            };
            
            if (Place == null)
            {
                return NotFound();
            }

            return Ok(PlaceDto);
        }

        // POST: api/PlaceData/UpdatePlace/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdatePlace(int id, Place place)
        {
            Debug.WriteLine("I have reached the update place method");
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("Model state is invalid");
                return BadRequest(ModelState);
            }

            if (id != place.PlaceId)
            {
                Debug.WriteLine("PlaceId does not match");
                Debug.WriteLine("GET parameter" + id);
                Debug.WriteLine("POST parameter" + place.PlaceId);
                Debug.WriteLine("POST parameter" + place.PlaceName);
                Debug.WriteLine("POST parameter " + place.PlaceDescription);
                return BadRequest();
            }

            db.Entry(place).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaceExists(id))
                {
                    Debug.WriteLine("Place DoesNot Exists");
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            Debug.WriteLine("None of the conditions trigerred");

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PlaceData/AddPlace
        [ResponseType(typeof(Place))]
        [HttpPost]
        public IHttpActionResult AddPlace(Place place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Places.Add(place);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = place.PlaceId }, place);
        }

        // POST: api/PlaceData/DeletePlace/5
        [ResponseType(typeof(Place))]
        [HttpPost]
        public IHttpActionResult DeletePlace(int id)
        {
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return NotFound();
            }

            db.Places.Remove(place);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlaceExists(int id)
        {
            return db.Places.Count(e => e.PlaceId == id) > 0;
        }
    }
}