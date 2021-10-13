using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.0, 10.0)]
        public double Rating { get; set; }

        [Required]
        public string Location { get; set; }

        public bool IsRecommended
        {
            get
            {
                return Rating >= 6;//same as an if else statement of true or false
            } 
        }
        //when adding new info to this class-
        //do the add-migration "info" and update-database
    }
}