using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class RestaurantSeed
    {
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public string OpeningHours { get; set; }
        public double CashBalance { get; set; }
        public ICollection<Menu> Menu { get; set; }
    }
}
