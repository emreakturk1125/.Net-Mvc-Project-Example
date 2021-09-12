﻿namespace MvcProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig_EditTable_Message1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsDraft", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "IsDraft");
        }
    }
}
