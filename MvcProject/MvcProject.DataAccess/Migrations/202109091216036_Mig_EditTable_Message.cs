namespace MvcProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig_EditTable_Message : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "MessageContent", c => c.String(maxLength: 2000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "MessageContent", c => c.String(maxLength: 100));
        }
    }
}
