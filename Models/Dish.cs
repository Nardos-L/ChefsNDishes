using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Tastiness { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int? Calories { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // 1 User : Many Post
        public int ChefId { get; set; }
        public Chef Cook { get; set; }
    }
}