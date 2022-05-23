using System;

namespace Models
{
    public class PurchaseResponse
    {
        public string UserName { get; set; }
        public double UserCashBalance { get; set; }
        public double RestaurantCashBalance { get; set; }
        public string DishName { get; set; }
        public DateTime TransactionDate { get; set; }
        public double TransactionAmount { get; set; }
        public string RestaurantName { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSucceed { get; set; }
    }
}
