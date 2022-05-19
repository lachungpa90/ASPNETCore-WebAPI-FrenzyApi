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
        private readonly IUsersRepository _user;
        public RequestHandler(IResturantRepository resturant, IUsersRepository user)
        {
            _resturant = resturant;

            _user = user;    
        }
        public async Task<List<Restaurant>>GetResturants()
        {
            var result = await _resturant.GetResturantsAsync();
            if (result == null)
                return null;
            return result.ToList();
        }
        public async Task<List<User>> GetUsers()
        {
            var result = await _user.GetUsersAsync();
            if (result == null)
                return null;
            return result.ToList();
        }
    }
}
