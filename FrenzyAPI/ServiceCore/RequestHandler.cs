using Contract;
using FrenzyAPI.Helper;
using Models;
using Models.DTOs;
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
        public async Task<List<Restaurant>>GetResturants( RestaurantParams restaurantParams )
        {
            var count = 0;
            var result = new List<Restaurant>();
            var allRestaurants = await _resturant.GetResturantsAsync();
            allRestaurants.ToList().ForEach(x => 
            {
                x.OpeningHours.ToList().ForEach(y => 
                {
                    if(y.OpeningTime.Equals(restaurantParams.Time)&& y.Days.Contains(restaurantParams.Day))
                    {
                        result.Add(x);
                        count++;
                    }
                });
            });

            //var result = allRestaurants.ToList().Where(x => x.OpeningHours
            //.Any(y => y.Days.ToLower().Contains(restaurantParams.Day)
            //&& y.OpeningTime.Trim().Equals(restaurantParams.Time))).ToList();

            if (result == null)
                return null;
            return result.Select(x=>new Restaurant { RestaurantName=x.RestaurantName, OpeningHours=x.OpeningHours, CashBalance=x.CashBalance}).ToList();
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
