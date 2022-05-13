using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Menu
    {
        public int Id { get; set; }
        public Resturant Resutrant { get; set; }
        public int ResturantId { get; set; }
        public string DishName { get; set; }
        public double Price { get; set; }
    }
}
