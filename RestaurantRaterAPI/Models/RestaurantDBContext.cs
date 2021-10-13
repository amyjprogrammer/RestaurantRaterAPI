using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI.Models
{
    //inheriting from dbcontext to establish a database connection
    public class RestaurantDbContext : DbContext
    {
        //Uses Constructor to pass the name of the connection string "DefaultConnection" to the DbContext
        public RestaurantDbContext() : base("DefaultConnection") { }

        //creating a property The DBSet holds the object we are wanting to store and its name will be the table name
        public DbSet<Restaurant> Restaurants { get; set; }//this is making the table in the database
        //use enable-migrations to start the database
        //add-migration "Initial Migration" after that
        //last one - update-database

        //Creating Ratings Table
        public DbSet<Rating> Ratings { get; set; }
    }
}