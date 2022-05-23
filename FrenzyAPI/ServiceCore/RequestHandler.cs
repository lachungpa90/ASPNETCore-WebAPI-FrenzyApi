using AutoMapper;
using Contract;
using Models;
using Models.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrenzyAPI.ServiceCore
{
    public class RequestHandler : IRequestHandler
    {
        private readonly IResturantRepository _resturant;
        private readonly IUsersRepository _user;
        private readonly IMapper _mapper;
        public RequestHandler(IResturantRepository resturant, IUsersRepository user, IMapper mapper)
        {
            _resturant = resturant;

            _user = user;
            _mapper = mapper;
        }
        public async Task<List<RestaurantDto>> GetResturants(RestaurantParams restaurantParams)
        {
            var result = new List<Restaurant>();
            var allRestaurants = await _resturant.GetResturantsAsync();
            allRestaurants.ToList().ForEach(x =>
            {
                x.OpeningHours.ToList().ForEach(y =>
                {
                    if (y.OpeningTime.Equals(restaurantParams.Time) && y.Days.Contains(restaurantParams.Day))
                        result.Add(x);
                });
            });
            var restaurantsToReturn = result.Select(x =>
            new RestaurantDto
            {
                RestaurantName = x.RestaurantName,
                CashBalance = x.CashBalance,
                OpeningHours = x.OpeningHours.Select(y =>
                 new OpeningHourDto
                 {
                     ClosingTime = y.ClosingTime,
                     OpeningTime = y.OpeningTime,
                     Days = y.Days
                 }).ToList()
            }).ToList();
            return restaurantsToReturn;
        }
        public async Task<RestaurantDto> GetRestaurant(string name)
        {
            var restautant = await _resturant.GetRestaurantAsync(name);
            var restaurantToReturn = _mapper.Map<RestaurantDto>(restautant);
            return restaurantToReturn;
        }
        public async Task<List<User>> GetUsers()
        {
            var result = await _user.GetUsersAsync();
            if (result == null)
                return null;
            return result.ToList();
        }
        public async Task<List<MenuDto>> GetDishes(string dishName)
        {
            var menu = await _resturant.GetDishes();
            var dishes = menu.Where(x => x.DishName.ToLower().Contains(dishName.ToLower()));
            var menuDto = _mapper.Map<List<MenuDto>>(dishes);
            return menuDto;
        }
        public async Task<List<string>> GetTopRestaurants(string query, double startPrice, double endPrice, int noOfDishes)
        {
            var isGreater = query == ">";
            var restaurantsNames = new List<string>();

            var restaurants = await _resturant.GetResturantsAsync();
            if (isGreater)
            {
                restaurants.Where(r => r.Menu.Count > noOfDishes).ToList().ForEach(x =>
                    {
                        PopulateRestaurantsName(x, restaurantsNames, startPrice, endPrice);
                    });
            }
            else
            {
                restaurants.Where(r => r.Menu.Count < noOfDishes).ToList().ForEach(x =>
                {
                    PopulateRestaurantsName(x, restaurantsNames, startPrice, endPrice);
                });
            }            
            return restaurantsNames.OrderBy(x=>x).ToList();
        }
        private void PopulateRestaurantsName(Restaurant ress, List<string> restaurantsNames, double startPrice, double endPrice)
        {
            if (ress != null)
            {
                ress.Menu.ToList().ForEach(y =>
                {
                    if (y.Price > startPrice && y.Price < endPrice)
                        restaurantsNames.Add(ress.RestaurantName);

                });
            }
        }
    }
}
