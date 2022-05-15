using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PurchaseHistory> PurchaseHistory { get; set; }
        public double CashBalance { get; set; }
    }

    public class PurchaseHistory
    {
        public int Id { get; set; }
        public string DishName { get; set; }
        public string RestaurantName { get; set; }
        public double TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
