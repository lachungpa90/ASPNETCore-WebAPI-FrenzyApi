using Contract;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrenzyAPI.ServiceCore
{
    public class RequestHandler: IRequestHandler
    {
        private readonly IResturantRepository _resturant;
        public RequestHandler(IResturantRepository resturant)
        {
            _resturant = resturant;
                
        }
        public async Task<List<Restaurant>>GetResturants()
        {
            var result = await _resturant.GetResturantsAsync();
            if (result == null)
                return null;
            return result.ToList();
        }
    }
}
