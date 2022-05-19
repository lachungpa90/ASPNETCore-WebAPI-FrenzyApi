using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTOs
{
    public class PurchaseHistoryDto
    {     
        public string DishName { get; set; }
        public string RestaurantName { get; set; }
        public double TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
