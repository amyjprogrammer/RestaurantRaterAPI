﻿using System;
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
        public double Rating 
        { 
            get 
            {
                if (Ratings.Count == 0)
                    return 0;

                double ratingScore = 0;

                foreach (var rating in Ratings)
                    ratingScore += rating.Score;

                return Math.Round(ratingScore / Ratings.Count, 2);
            } 
        }

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

        //navigation property for one to many relationship with ratings
        //news it up if the list is blank
        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();

        //screen shot window key (next to alt and ctrl) + shift + s
    }
}