namespace NBC.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UnitActivities", "SVActivityYear_Id", c => c.Int());
            AddColumn("dbo.SVActivityYears", "ActionType_Id", c => c.Int());
            AddColumn("dbo.SVActivityYears", "Year_Id", c => c.Int());
            CreateIndex("dbo.UnitActivities", "SVActivityYear_Id");
            CreateIndex("dbo.SVActivityYears", "ActionType_Id");
            CreateIndex("dbo.SVActivityYears", "Year_Id");
            AddForeignKey("dbo.SVActivityYears", "ActionType_Id", "dbo.ActionTypes", "Id");
            AddForeignKey("dbo.UnitActivities", "SVActivityYear_Id", "dbo.SVActivityYears", "Id");
            AddForeignKey("dbo.SVActivityYears", "Year_Id", "dbo.Years", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SVActivityYears", "Year_Id", "dbo.Years");
            DropForeignKey("dbo.UnitActivities", "SVActivityYear_Id", "dbo.SVActivityYears");
            DropForeignKey("dbo.SVActivityYears", "ActionType_Id", "dbo.ActionTypes");
            DropIndex("dbo.SVActivityYears", new[] { "Year_Id" });
            DropIndex("dbo.SVActivityYears", new[] { "ActionType_Id" });
            DropIndex("dbo.UnitActivities", new[] { "SVActivityYear_Id" });
            DropColumn("dbo.SVActivityYears", "Year_Id");
            DropColumn("dbo.SVActivityYears", "ActionType_Id");
            DropColumn("dbo.UnitActivities", "SVActivityYear_Id");
        }
    }
}
