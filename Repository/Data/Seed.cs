using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class Seed
    {
        public async Task SeedResturant(DataContext context)
        {
            if (await context.Resturants.AnyAsync()) return;
            var resturantData = await System.IO.File.ReadAllTextAsync("Data/ResturantSeedData.json");
            var resturants = JsonSerializer.Deserialize<List<Resturant>>(resturantData);
            foreach(var resutrant in resturants)
            {
                context.Resturants.Add(resutrant);
            }
            await context.SaveChangesAsync();
        }
    }
}
