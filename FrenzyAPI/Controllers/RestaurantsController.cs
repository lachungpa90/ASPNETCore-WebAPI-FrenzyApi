using Contract;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrenzyAPI.Controllers
{
    public class RestaurantsController:BaseApiController
    {
        private readonly IRequestHandler _handler;
        public RestaurantsController(IRequestHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public async Task<ActionResult<List<RestaurantDto>>>GetResturants([FromQuery]RestaurantParams restaurantParams)
        {
            return await _handler.GetResturants(restaurantParams);
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<RestaurantDto>>GetRestaurant(string name)
        {
            return await _handler.GetRestaurant(name);
        }

        [HttpGet("{dishName}/RestaurantMenu")]
        public async Task<ActionResult<List<MenuDto>>> GetRestaurantMenu([FromQuery]string dishName)
        {
            return await _handler.GetDishes(dishName);
        }


    }
}
