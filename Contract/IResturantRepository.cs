using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contract
{
    public interface  IResturantRepository
    {
        Task<IEnumerable<Restaurant>> GetResturantsAsync();
        Task<Restaurant> GetRestaurantAsync(string name);
        Task<IEnumerable<Menu>> GetDishes();
        void Update(Restaurant restaurant);
        Task<bool> SaveAllAsync();
    }
}
