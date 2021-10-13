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
    public class RestaurantController : ApiController
    {
        //connection to where we have our data
        private readonly RestaurantDbContext _context = new RestaurantDbContext();
        //CRUD
        //PGPD

        //Create or Post
        [HttpPost]
        public async Task<IHttpActionResult> PostRestaurant(Restaurant model)
        {
            if (model == null)
                return BadRequest("restaurant cannot be null");//makes sure we weren't given an empty object model

            //making sure that required or range are valid
            if (ModelState.IsValid)
            {
                _context.Restaurants.Add(model);
                await _context.SaveChangesAsync();//this enters something into the database

                return Ok();
            }
            //if model stat is bad
            return BadRequest(ModelState);//shows exactly what is wrong
        }

        //Reading or Get
        [HttpGet]
        public async Task<IHttpActionResult> GetRestaurant()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        //GetById
        [HttpGet]
        public async Task<IHttpActionResult> GetRestaurantById(int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);

            if (restaurant != null)
            {
                return Ok(restaurant);
            }
            //if the system can't find the restaurant
            return NotFound();//404
        }

        [HttpPut]  //from uri - getting the int from the uri and the restaurant update from the body
        public async Task<IHttpActionResult> UpdateRestaurant([FromUri]int id, [FromBody]Restaurant model)
        {
            if (model == null)
                return BadRequest("restaurant cannot be null");//makes sure we weren't given an empty object model

            if (ModelState.IsValid)
            {
                Restaurant restaurant = await _context.Restaurants.FindAsync(id);

                if (restaurant != null)
                {
                    restaurant.Name = model.Name;
                    restaurant.Rating = model.Rating;
                    restaurant.Location = model.Location;

                    await _context.SaveChangesAsync();
                    return Ok();
                }
                //shows the 404
                return NotFound();
            }
            //was null
            return BadRequest(ModelState);//telling them what is wrong
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRestaurantById([FromUri]int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);

            if (restaurant == null)
                return NotFound();

            //Restaurtant was found
            _context.Restaurants.Remove(restaurant);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
