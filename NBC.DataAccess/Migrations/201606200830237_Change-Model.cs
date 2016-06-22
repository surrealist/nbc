namespace NBC.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SVActivityYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Target = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SV_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SVs", t => t.SV_Id)
                .Index(t => t.SV_Id);
            
            CreateTable(
                "dbo.SVUnitYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SV_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SVs", t => t.SV_Id)
                .Index(t => t.SV_Id);
            
            AddColumn("dbo.ActualWorks", "ActionType_Id", c => c.Int());
            AddColumn("dbo.ActualWorks", "TimeTable_Id", c => c.Int());
            AddColumn("dbo.Applicants", "ActualWork_Id", c => c.Int());
            AddColumn("dbo.Companies", "Address_CreatedBy", c => c.String(maxLength: 255));
            AddColumn("dbo.Companies", "Address_CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Companies", "Address_ModifiedBy", c => c.String(maxLength: 255));
            AddColumn("dbo.Companies", "Address_ModifiedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.People", "Address_CreatedBy", c => c.String(maxLength: 255));
            AddColumn("dbo.People", "Address_CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.People", "Address_ModifiedBy", c => c.String(maxLength: 255));
            AddColumn("dbo.People", "Address_ModifiedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.UnitActivities", "CreatedBy", c => c.String(maxLength: 255));
            AddColumn("dbo.UnitActivities", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.UnitActivities", "ModifiedBy", c => c.String(maxLength: 255));
            AddColumn("dbo.UnitActivities", "ModifiedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Consultants", "Address_CreatedBy", c => c.String(maxLength: 255));
            AddColumn("dbo.Consultants", "Address_CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Consultants", "Address_ModifiedBy", c => c.String(maxLength: 255));
            AddColumn("dbo.Consultants", "Address_ModifiedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Units", "Adress_CreatedBy", c => c.String(maxLength: 255));
            AddColumn("dbo.Units", "Adress_CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Units", "Adress_ModifiedBy", c => c.String(maxLength: 255));
            AddColumn("dbo.Units", "Adress_ModifiedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.People", "CitizenId", c => c.Int());
            CreateIndex("dbo.ActualWorks", "ActionType_Id");
            CreateIndex("dbo.ActualWorks", "TimeTable_Id");
            CreateIndex("dbo.Applicants", "ActualWork_Id");
            AddForeignKey("dbo.ActualWorks", "ActionType_Id", "dbo.ActionTypes", "Id");
            AddForeignKey("dbo.Applicants", "ActualWork_Id", "dbo.ActualWorks", "Id");
            AddForeignKey("dbo.ActualWorks", "TimeTable_Id", "dbo.TimeTables", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SVUnitYears", "SV_Id", "dbo.SVs");
            DropForeignKey("dbo.SVActivityYears", "SV_Id", "dbo.SVs");
            DropForeignKey("dbo.ActualWorks", "TimeTable_Id", "dbo.TimeTables");
            DropForeignKey("dbo.Applicants", "ActualWork_Id", "dbo.ActualWorks");
            DropForeignKey("dbo.ActualWorks", "ActionType_Id", "dbo.ActionTypes");
            DropIndex("dbo.SVUnitYears", new[] { "SV_Id" });
            DropIndex("dbo.SVActivityYears", new[] { "SV_Id" });
            DropIndex("dbo.Applicants", new[] { "ActualWork_Id" });
            DropIndex("dbo.ActualWorks", new[] { "TimeTable_Id" });
            DropIndex("dbo.ActualWorks", new[] { "ActionType_Id" });
            AlterColumn("dbo.People", "CitizenId", c => c.Int(nullable: false));
            DropColumn("dbo.Units", "Adress_ModifiedDate");
            DropColumn("dbo.Units", "Adress_ModifiedBy");
            DropColumn("dbo.Units", "Adress_CreatedDate");
            DropColumn("dbo.Units", "Adress_CreatedBy");
            DropColumn("dbo.Consultants", "Address_ModifiedDate");
            DropColumn("dbo.Consultants", "Address_ModifiedBy");
            DropColumn("dbo.Consultants", "Address_CreatedDate");
            DropColumn("dbo.Consultants", "Address_CreatedBy");
            DropColumn("dbo.UnitActivities", "ModifiedDate");
            DropColumn("dbo.UnitActivities", "ModifiedBy");
            DropColumn("dbo.UnitActivities", "CreatedDate");
            DropColumn("dbo.UnitActivities", "CreatedBy");
            DropColumn("dbo.People", "Address_ModifiedDate");
            DropColumn("dbo.People", "Address_ModifiedBy");
            DropColumn("dbo.People", "Address_CreatedDate");
            DropColumn("dbo.People", "Address_CreatedBy");
            DropColumn("dbo.Companies", "Address_ModifiedDate");
            DropColumn("dbo.Companies", "Address_ModifiedBy");
            DropColumn("dbo.Companies", "Address_CreatedDate");
            DropColumn("dbo.Companies", "Address_CreatedBy");
            DropColumn("dbo.Applicants", "ActualWork_Id");
            DropColumn("dbo.ActualWorks", "TimeTable_Id");
            DropColumn("dbo.ActualWorks", "ActionType_Id");
            DropTable("dbo.SVUnitYears");
            DropTable("dbo.SVActivityYears");
        }
    }
}
