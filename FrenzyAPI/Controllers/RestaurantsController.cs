using Contract;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult<List<Restaurant>>>GetResturants()
        {
            var resturants =await _handler.GetResturants();
            if (resturants is null)
                return NotFound(resturants);
            return Ok(resturants);
        }


    }
}
