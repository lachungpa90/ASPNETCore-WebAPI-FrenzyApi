using System.ComponentModel.DataAnnotations;

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
