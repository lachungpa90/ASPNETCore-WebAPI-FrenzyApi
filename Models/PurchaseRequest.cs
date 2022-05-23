using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
   public class PurchaseRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        public string DishName { get; set; }
    }
}
