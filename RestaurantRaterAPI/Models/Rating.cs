using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        //Foreign Key
        [ForeignKey(nameof(Restaurant))]//this restaurant is the same for the second one in the property below
        public int RestaurantId { get; set; }

        //Navigation Property
        public virtual Restaurant Restaurant { get; set; }

        [Required]
        [Range(0.0, 10.0)]
        public double Score { get; set; }

    }
}