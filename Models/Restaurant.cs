using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{    
    public class Restaurant
    {
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public ICollection<OpeningHour> OpeningHours { get; set; }
        public double CashBalance { get; set; }
        public ICollection<Menu> Menu { get; set; }         

    }

    public class OpeningHour
    {
        public int Id { get; set; }
        public string Days { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime{ get; set; }
        public Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }
    }
}
