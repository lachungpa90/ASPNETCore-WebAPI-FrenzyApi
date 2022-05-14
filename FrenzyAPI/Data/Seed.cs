using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FrenzyAPI
{
    public class Seed
    {
        public static  async Task SeedResturant(DataContext context)
        {
            if (await context.Restaurants.AnyAsync()) return;
            var restaurantData = await System.IO.File.ReadAllTextAsync("Data/RestaurantSeedData.json");
            var restaurants = JsonSerializer.Deserialize<List<Restaurant>>(restaurantData);
            foreach(var restaurant in restaurants)
            {
                context.Restaurants.Add(restaurant);
            }
            await context.SaveChangesAsync();
        }
    }
}
