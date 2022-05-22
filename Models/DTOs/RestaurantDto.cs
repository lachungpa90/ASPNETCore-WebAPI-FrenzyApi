using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTOs
{
    public class RestaurantDto
    {
        public string RestaurantName { get; set; }
        public ICollection<OpeningHourDto> OpeningHours { get; set; }
        public double CashBalance { get; set; }
    }
}
