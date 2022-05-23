using AutoMapper;
using Contract;
using Models;
using Models.DTOs;
using System;
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
        public async Task<User>GetUserById(int id)
        {
            return await _user.GetUserById(id);
        }
        public async Task<PurchaseResponse> PurchaseDish(PurchaseRequest request)
        {
            var response = new PurchaseResponse();

            var user = await  _user.GetUserById(request.UserId);
            var restaurant = await _resturant.GetRestaurantAsync(request.RestaurantName);
            if (user == null || restaurant == null)
                return response;
            var dish = restaurant.Menu.SingleOrDefault(x => x.DishName == request.DishName);
            if (dish.Price > user.CashBalance)
            {
                response.ErrorMessage = "User dont have sufficient balance to place an order" ;
                return response;
            }
            PopulateResponse(response, user, restaurant, dish, request);
            UpdatePurchaseHistory(response,request.UserId);
            UpdateUser(user, response);
            UpdateRestaurant(response, restaurant);
            return response;
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
        private void UpdateRestaurant(PurchaseResponse response, Restaurant restaurant)
        {
            restaurant.CashBalance = response.RestaurantCashBalance;
            _resturant.Update(restaurant);
            _resturant.SaveAllAsync();
            response.IsSucceed = true;
        }
        private void UpdateUser(User user, PurchaseResponse response)
        {
            user.CashBalance = response.UserCashBalance;
            _user.Update(user);
            _user.SaveAllAsync();
        }
        private void PopulateResponse(PurchaseResponse response, User user, Restaurant restaurant,Menu dish, PurchaseRequest request)
        {
            response.UserName = user.Name;//to be updated
            response.UserCashBalance = Math.Round(user.CashBalance - dish.Price, 2);
            response.TransactionDate = DateTime.Now;
            response.TransactionAmount = dish.Price;
            response.RestaurantName = restaurant.RestaurantName;
            response.RestaurantCashBalance =Math.Round(restaurant.CashBalance + dish.Price, 2);//need to be updated
            response.DishName = request.DishName;
        }
        private void UpdatePurchaseHistory(PurchaseResponse response, int id)
        {
            var purchaseHistory = new PurchaseHistory
            {
                DishName = response.DishName,
                RestaurantName = response.RestaurantName,
                TransactionAmount = response.TransactionAmount,
                TransactionDate = response.TransactionDate
            };
            _user.AddPurchaseHistory(id, purchaseHistory);          
        }
    }

}
