namespace tutor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfirmLecture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lectures", "Confirmed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lectures", "Confirmed");
        }
    }
}
