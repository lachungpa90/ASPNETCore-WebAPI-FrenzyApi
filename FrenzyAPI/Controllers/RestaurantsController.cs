using AutoMapper;
using Contract;
using FrenzyAPI.Helper;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrenzyAPI.Controllers
{
    public class RestaurantsController:BaseApiController
    {
        private readonly IRequestHandler _handler;
        private readonly IMapper _mapper;
        public RestaurantsController(IRequestHandler handler, IMapper mapper)
        {
            _handler = handler;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<RestaurantDto>>>GetResturants([FromQuery]RestaurantParams restaurantParams)
        {
            var resturants = await _handler.GetResturants(restaurantParams);
            var restaurantsToReturn = resturants.Select(x =>
              new RestaurantDto
              {
                  RestaurantName = x.RestaurantName,
                  CashBalance = x.CashBalance,
                  OpeningHours = x.OpeningHours
              }).ToList();
            return Ok(restaurantsToReturn);
        }


    }
}
