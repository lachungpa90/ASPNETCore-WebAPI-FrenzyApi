using Models;
using Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contract
{
    public interface IRequestHandler
    {
        Task<List<RestaurantDto>> GetResturants(RestaurantParams restaurantParams);
        Task<List<User>> GetUsers();
        Task<RestaurantDto> GetRestaurant(string name);
        Task<List<MenuDto>> GetDishes(string dishName);
        Task<List<string>> GetTopRestaurants(string query, double startPrice, double endPrice, int noOfDishes);
        Task<PurchaseResponse> PurchaseDish(PurchaseRequest request);
        Task<User> GetUserById(int id);
    }
}
