using System.Collections.Generic;

namespace Models.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PurchaseHistoryDto> PurchaseHistory { get; set; }
        public double CashBalance { get; set; }
    }
}
