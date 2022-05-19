using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

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
