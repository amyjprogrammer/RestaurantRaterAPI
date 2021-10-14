namespace RestaurantRaterAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedRatingLogicInRestaurant : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Restaurants", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "Rating", c => c.Double(nullable: false));
        }
    }
}
