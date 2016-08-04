namespace NBC.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jomeSV : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.SVActivityYears", "SV_Id", "dbo.WorkPlaces");
            //DropIndex("dbo.SVActivityYears", new[] { "SV_Id" });
            //AlterColumn("dbo.SVActivityYears", "SV_Id", c => c.Int(nullable: false));
            //CreateIndex("dbo.SVActivityYears", "SV_Id");
            //AddForeignKey("dbo.SVActivityYears", "SV_Id", "dbo.WorkPlaces", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.SVActivityYears", "SV_Id", "dbo.WorkPlaces");
            //DropIndex("dbo.SVActivityYears", new[] { "SV_Id" });
            //AlterColumn("dbo.SVActivityYears", "SV_Id", c => c.Int());
            //CreateIndex("dbo.SVActivityYears", "SV_Id");
            //AddForeignKey("dbo.SVActivityYears", "SV_Id", "dbo.WorkPlaces", "Id");
        }
    }
}
