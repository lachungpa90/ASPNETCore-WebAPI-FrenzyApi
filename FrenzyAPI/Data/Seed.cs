using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrenzyAPI
{
    public class Seed
    {
        public static async Task SeedResturant(DataContext context)
        {
            if (await context.Restaurants.AnyAsync()) return;
            var restaurantData = await System.IO.File.ReadAllTextAsync("Data/ResturantSeed.json");
            var restaurantDto = JsonConvert.DeserializeObject<List<RestaurantSeed>>(restaurantData);          
            
            foreach (var resDto in restaurantDto)
            {
                var restaurant = new Restaurant();
                restaurant.OpeningHours = new List<OpeningHour>();
                restaurant.Menu = resDto.Menu;
                restaurant.CashBalance = resDto.CashBalance;
                restaurant.RestaurantName = resDto.RestaurantName;
                restaurant.OpeningHours = GetOpeningHour(resDto.OpeningHours);
                context.Restaurants.Add(restaurant);
            }
            await context.SaveChangesAsync();
        }
        public static async Task SeedUsers(DataContext context)
        {  
            
            if (await context.Users.AnyAsync()) return;
            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeed.json");
            var usersDto = JsonConvert.DeserializeObject<List<UserSeed>>(userData);
             
            foreach (var dto in usersDto)
            {
                var user = new User();
                user.CashBalance = dto.CashBalance;
                user.Name = dto.Name;
                user.PurchaseHistory = dto.PurchaseHistory;
                context.Users.Add(user);
            }
            await context.SaveChangesAsync();
        }
        private static List <OpeningHour> GetOpeningHour(string openingTime)
        {
            var op = new List<OpeningHour>();
            try
            {
            var count = 0;    
            openingTime.Split('/').ToList().ForEach(x =>
            {
                var openingHour = new OpeningHour();
                var oT = new List<string>();
                var cT = new List<string>();
                var days = new List<string>();
                if (x.Contains(','))
                {
                    var s = x.Split(',');
                    days.Add(s[0]);
                    if (s.Count() > 2)
                    {
                        days.Add(s[1]);
                        AddHours(s[2], days, oT, cT);
                    }
                    else
                    {
                        AddHours(s[1], days, oT, cT);
                    }
                }
                else
                {
                    AddHours(x, days, oT, cT);
                }
                count++;
                openingHour.Days = string.Join(',', days).Trim();
                openingHour.OpeningTime = string.Join(',', oT);
                openingHour.ClosingTime = string.Join(',', cT);
                op.Add(openingHour);
            });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }
            return op;
        }
        private static void AddHours(string f, List<string> day, List<string> openingTime, List<string> ClosingTime)
        {
            var c = f.Trim().Split(' ');
            day.Add(c[0]);
            if(c.Length==8)
            {
                day.Add(c[2]);
                openingTime.Add(ConvertInto24hrsFormat(c[3] +" "+ c[4]));
                ClosingTime.Add(ConvertInto24hrsFormat(c[6] + " " + c[7]));
            }
            else
            {
                openingTime.Add(ConvertInto24hrsFormat(c[1] + " " + c[2]));
                ClosingTime.Add(ConvertInto24hrsFormat(c[4] + " " + c[5]));
            }

        }
        private static string ConvertInto24hrsFormat(string input)
        {
            return DateTime.Parse(input).ToString("HH:mm");
        }
    }
}
