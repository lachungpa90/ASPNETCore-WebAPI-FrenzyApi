using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Models
{
   public class UserSeed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PurchaseHistory> PurchaseHistory { get; set; }
        public double CashBalance { get; set; }
    }
}
