namespace tutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class styduplaceimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudyPlaces", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudyPlaces", "Image");
        }
    }
}
