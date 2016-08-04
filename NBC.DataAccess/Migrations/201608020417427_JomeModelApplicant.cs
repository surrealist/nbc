namespace NBC.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JomeModelApplicant : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UnitActivities", "IX_UnitActivityName");
            AddColumn("dbo.Applicants", "FinishDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.UnitActivities", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UnitActivities", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Applicants", "FinishDate");
            CreateIndex("dbo.UnitActivities", "Name", unique: true, name: "IX_UnitActivityName");
        }
    }
}
