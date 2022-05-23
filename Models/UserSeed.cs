using System.Collections.Generic;

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
