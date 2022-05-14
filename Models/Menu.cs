using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Menu
    {
        public int Id { get; set; }
        public Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }
        public string DishName { get; set; }
        public double Price { get; set; }
    }
}
