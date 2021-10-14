using RestaurantRaterAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRaterAPI.Controllers
{
    public class RatingController : ApiController
    {
        //Repo pattern 2.0
        //CRUD
        //Where we store our Data
        RestaurantDbContext _context = new RestaurantDbContext();

        //Post or Create
        [HttpPost]
        public async Task<IHttpActionResult> PostRating(Rating model)
        {
            //handling no info and bad info
            if (model == null)
                return BadRequest("You must enter information");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Ratings.Add(model);
            //remember to save the data
            await _context.SaveChangesAsync();

            return Ok($"Your rating of {model.Score} was added.");
        }

        //Read or Get
        [HttpGet]
        public async Task<IHttpActionResult> GetAllRatings()
        {
            List<Rating> ratings = await _context.Ratings.ToListAsync();
            return Ok(ratings);
        }

    }
}
