using Contract;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrenzyAPI.Controllers
{
    public class PurchaseController:BaseApiController
    {
        private readonly IRequestHandler _handler;
        public PurchaseController(IRequestHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<ActionResult<PurchaseResponse>>PurchaseDish([FromBody]PurchaseRequest request)
        {
            var res = await _handler.PurchaseDish(request);
            if (res.IsSucceed)
                return Ok(res);
            return NotFound(res);
        }
    }
}
