using Microsoft.AspNetCore.Mvc;
using RestaurantUI.Models;
using RestaurantUI.Services;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly FakeRestaurantService _service;

        public RestaurantController(FakeRestaurantService service)
        {
            _service = service;
        }

        // GET api/restaurant
        [HttpGet]
        public ActionResult<List<Restaurant>> GetAll() => _service.Restaurants;

        // GET api/restaurant/1
        [HttpGet("{id}")]
        public ActionResult<Restaurant> GetById(int id)
        {
            var r = _service.GetRestaurantById(id);
            if (r == null) return NotFound();
            return r;
        }

        // POST api/restaurant
        [HttpPost]
        public ActionResult<Restaurant> Add(Restaurant r)
        {
            _service.AddRestaurant(r);
            return CreatedAtAction(nameof(GetById), new { id = r.Id }, r);
        }

        // PUT api/restaurant/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, Restaurant r)
        {
            var existing = _service.GetRestaurantById(id);
            if (existing == null) return NotFound();
            _service.UpdateRestaurant(r);
            return NoContent();
        }

        // DELETE api/restaurant/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteRestaurant(id);
            return NoContent();
        }

        // POST api/restaurant/1/reviews
        [HttpPost("{id}/reviews")]
        public IActionResult AddReview(int id, Review review)
        {
            var r = _service.GetRestaurantById(id);
            if (r == null) return NotFound();
            _service.AddReview(id, review);
            return Ok(review);
        }
    }
}