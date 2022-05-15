using Microsoft.EntityFrameworkCore;
using Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrenzyAPI
{
    public class Seed
    {
        public static async Task SeedResturant(DataContext context)
        {
            if (await context.Restaurants.AnyAsync()) return;
            var restaurantData = await System.IO.File.ReadAllTextAsync("Data/RestaurantSeedData.json");
            var restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(restaurantData);
            foreach (var restaurant in restaurants)
            {
                context.Restaurants.Add(restaurant);
            }
            await context.SaveChangesAsync();
        }
        public static async Task SeedUsers(DataContext context)
        {  
            
            if (await context.Users.AnyAsync()) return;
            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<Users>>(userData);
            foreach (var user in users)
            {
                context.Users.Add(user);
            }
            await context.SaveChangesAsync();
        }
    }
}
