using Contract;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrenzyAPI.Repository
{
    public class ResturantRepository: IResturantRepository
    {
        private readonly DataContext _context;
        public ResturantRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Restaurant>>GetResturantsAsync()
        {
            return await _context.Restaurants.Include(x => x.OpeningHours).Include(y => y.Menu).ToListAsync();             
        }
        public async Task<Restaurant>GetRestaurantAsync(string name)
        {
           return await _context.Restaurants.SingleOrDefaultAsync(x => x.RestaurantName == name);
        }

        public async Task<IEnumerable<Menu>> GetDishes()
        {
           return await _context.Restaurants.Include(x => x.Menu).SelectMany(y => y.Menu).Distinct().ToListAsync();
        }
    }
}
