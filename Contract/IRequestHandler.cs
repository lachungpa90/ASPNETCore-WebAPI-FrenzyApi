using Models;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IRequestHandler
    {
        Task<List<RestaurantDto>> GetResturants(RestaurantParams restaurantParams);
        Task<List<User>> GetUsers();
        Task<RestaurantDto> GetRestaurant(string name);
        Task<List<MenuDto>> GetDishes(string dishName);
    }
}
