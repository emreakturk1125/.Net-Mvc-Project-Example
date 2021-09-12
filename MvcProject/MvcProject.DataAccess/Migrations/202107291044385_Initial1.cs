namespace MvcProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Abouts", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "Status", c => c.Boolean(nullable: false));
        }
    }
}
