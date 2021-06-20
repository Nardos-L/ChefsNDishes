using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key] // denotes PK, not needed if named ModelNameId
        public int ChefId { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "is required.")]
        [Display(Name = "Date of Birth")]
        public DateTime Birthday { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* Foreign Keys and Navigation Properties for Relationships */

        // 1 Chef : Many Dish

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        public int Age {
            get { return DateTime.Now.Year - Birthday.Year;}
        }
        public List<Dish> Dishes { get; set; }
    }
}