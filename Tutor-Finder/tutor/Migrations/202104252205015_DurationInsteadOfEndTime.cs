namespace tutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DurationInsteadOfEndTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lectures", "Duration", c => c.Int(nullable: false));
            DropColumn("dbo.Lectures", "EndTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lectures", "EndTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Lectures", "Duration");
        }
    }
}
