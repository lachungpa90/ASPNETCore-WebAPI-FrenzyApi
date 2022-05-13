using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table ("Resturants")]
    public class Resturant
    {
        public int Id { get; set; }
        public string ResturantName { get; set; }
        public string OpeningHours { get; set; }
        public double CashBalance { get; set; }
        public ICollection<Menu> MyProperty { get; set; }
    }

  
}
