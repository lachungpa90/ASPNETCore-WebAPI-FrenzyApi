using Contract;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrenzyAPI.Controllers
{
    public class RestaurantsController : BaseApiController
    {
        private readonly IRequestHandler _handler;
        public RestaurantsController(IRequestHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public async Task<ActionResult<List<RestaurantDto>>> GetResturants([FromQuery] RestaurantParams restaurantParams)
        {
            return await _handler.GetResturants(restaurantParams);
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<RestaurantDto>> GetRestaurant(string name)
        {
            return await _handler.GetRestaurant(name);
        }

        [HttpGet("/RestaurantMenu")]
        public async Task<ActionResult<List<MenuDto>>> GetRestaurantMenu([FromQuery] string dishName)
        {
            return await _handler.GetDishes(dishName);
        }

        [HttpGet("/TopRestaurants")]
        public async Task<ActionResult<List<RestaurantDto>>>GetTopRestaurants([FromQuery] string query, int startPrice, int endPrice, int noOfDishes)
        {
            var result = await _handler.GetTopRestaurants(query, startPrice, endPrice, noOfDishes);
            if (result.Any())
                return Ok(result);
            return NotFound("No Restaurants Found");
        }
    }
}
