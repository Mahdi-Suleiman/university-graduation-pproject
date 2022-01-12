namespace tutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LecturePrices : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "OneHourPrice", c => c.Double(nullable: false));
            AddColumn("dbo.AspNetUsers", "TwoHourPrice", c => c.Double(nullable: false));
            AddColumn("dbo.AspNetUsers", "ThreeHourPrice", c => c.Double(nullable: false));
            DropColumn("dbo.Lectures", "OneHourPrice");
            DropColumn("dbo.Lectures", "TwoHourPrice");
            DropColumn("dbo.Lectures", "ThreeHourPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lectures", "ThreeHourPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Lectures", "TwoHourPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Lectures", "OneHourPrice", c => c.Double(nullable: false));
            DropColumn("dbo.AspNetUsers", "ThreeHourPrice");
            DropColumn("dbo.AspNetUsers", "TwoHourPrice");
            DropColumn("dbo.AspNetUsers", "OneHourPrice");
        }
    }
}
