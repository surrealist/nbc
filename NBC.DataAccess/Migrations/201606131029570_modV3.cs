namespace NBC.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modV3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ActualWorks",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SeqId = c.Int(nullable: false),
                        ActionDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ActionDetail = c.String(),
                        ActionManDay = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ApplyDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        isApproveTimeTable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        ComCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Consultants",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Citizenid = c.Int(nullable: false),
                        Title = c.String(),
                        FirstName = c.String(),
                        SurName = c.String(),
                        Address = c.String(),
                        Tel = c.String(),
                        Email = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(),
                        FirstName = c.String(),
                        SurName = c.Int(nullable: false),
                        CitizenId = c.Int(nullable: false),
                        Address = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        isMainPerson = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SVs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Alias = c.String(),
                        Tel = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeTables",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SeqId = c.Int(nullable: false),
                        PlanDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PlanDetail = c.String(),
                        PlanManDay = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Units", "Name", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Units", "Name", c => c.String(maxLength: 100));
            DropTable("dbo.TimeTables");
            DropTable("dbo.SVs");
            DropTable("dbo.People");
            DropTable("dbo.Consultants");
            DropTable("dbo.Companies");
            DropTable("dbo.Applicants");
            DropTable("dbo.ActualWorks");
            DropTable("dbo.ActionTypes");
        }
    }
}
