namespace NBC.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDbAct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ActivityTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(maxLength: 255),
                        ModifiedBy = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ActualWorks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeqId = c.Int(nullable: false),
                        ActionDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ActionDetail = c.String(maxLength: 2048),
                        ActionManDay = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ActionType_Id = c.Int(),
                        TimeTable_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActionTypes", t => t.ActionType_Id)
                .ForeignKey("dbo.TimeTables", t => t.TimeTable_Id)
                .Index(t => t.ActionType_Id)
                .Index(t => t.TimeTable_Id);
            
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplyDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsApproveTimeTable = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Company_Id = c.Int(),
                        Person_Id = c.Int(),
                        UnitActivity_Id = c.Int(),
                        ActualWork_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .ForeignKey("dbo.UnitActivities", t => t.UnitActivity_Id)
                .ForeignKey("dbo.ActualWorks", t => t.ActualWork_Id)
                .Index(t => t.Company_Id)
                .Index(t => t.Person_Id)
                .Index(t => t.UnitActivity_Id)
                .Index(t => t.ActualWork_Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Address_No = c.String(maxLength: 255),
                        Address_Moo = c.String(maxLength: 255),
                        Address_MooBan = c.String(maxLength: 255),
                        Address_Building = c.String(maxLength: 255),
                        Address_Floor = c.String(maxLength: 255),
                        Address_Soi = c.String(maxLength: 255),
                        Address_Road = c.String(maxLength: 255),
                        Address_Tambol_Id = c.Int(nullable: false),
                        Address_Tambol = c.String(maxLength: 255),
                        Address_Amphoe_Id = c.Int(nullable: false),
                        Address_Amphoe = c.String(maxLength: 255),
                        Address_ProvinceCode = c.Int(nullable: false),
                        Address_ZipCode = c.String(maxLength: 5),
                        Address_Latitude = c.Single(nullable: false),
                        Address_Longtitude = c.Single(nullable: false),
                        Address_CreatedBy = c.String(maxLength: 255),
                        Address_CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Address_ModifiedBy = c.String(maxLength: 255),
                        Address_ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ComCode = c.String(maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 255),
                        FirstName = c.String(maxLength: 255),
                        SurName = c.String(maxLength: 255),
                        CitizenId = c.Int(),
                        Address_No = c.String(maxLength: 255),
                        Address_Moo = c.String(maxLength: 255),
                        Address_MooBan = c.String(maxLength: 255),
                        Address_Building = c.String(maxLength: 255),
                        Address_Floor = c.String(maxLength: 255),
                        Address_Soi = c.String(maxLength: 255),
                        Address_Road = c.String(maxLength: 255),
                        Address_Tambol_Id = c.Int(nullable: false),
                        Address_Tambol = c.String(maxLength: 255),
                        Address_Amphoe_Id = c.Int(nullable: false),
                        Address_Amphoe = c.String(maxLength: 255),
                        Address_ProvinceCode = c.Int(nullable: false),
                        Address_ZipCode = c.String(maxLength: 5),
                        Address_Latitude = c.Single(nullable: false),
                        Address_Longtitude = c.Single(nullable: false),
                        Address_CreatedBy = c.String(maxLength: 255),
                        Address_CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Address_ModifiedBy = c.String(maxLength: 255),
                        Address_ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Mobile = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        isMainPerson = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UnitActivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Target = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SVActivityYear_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SVActivityYears", t => t.SVActivityYear_Id)
                .Index(t => t.SVActivityYear_Id);
            
            CreateTable(
                "dbo.TimeTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeqId = c.Int(nullable: false),
                        PlanDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PlanDetail = c.String(maxLength: 2048),
                        PlanManDay = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicantConsults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Consultants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Citizenid = c.Int(nullable: false),
                        Title = c.String(maxLength: 255),
                        FirstName = c.String(maxLength: 255),
                        SurName = c.String(maxLength: 255),
                        Address_No = c.String(maxLength: 255),
                        Address_Moo = c.String(maxLength: 255),
                        Address_MooBan = c.String(maxLength: 255),
                        Address_Building = c.String(maxLength: 255),
                        Address_Floor = c.String(maxLength: 255),
                        Address_Soi = c.String(maxLength: 255),
                        Address_Road = c.String(maxLength: 255),
                        Address_Tambol_Id = c.Int(nullable: false),
                        Address_Tambol = c.String(maxLength: 255),
                        Address_Amphoe_Id = c.Int(nullable: false),
                        Address_Amphoe = c.String(maxLength: 255),
                        Address_ProvinceCode = c.Int(nullable: false),
                        Address_ZipCode = c.String(maxLength: 5),
                        Address_Latitude = c.Single(nullable: false),
                        Address_Longtitude = c.Single(nullable: false),
                        Address_CreatedBy = c.String(maxLength: 255),
                        Address_CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Address_ModifiedBy = c.String(maxLength: 255),
                        Address_ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Tel = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        Notes = c.String(maxLength: 2048),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Profile = c.String(nullable: false, maxLength: 128),
                        CurrentYearId = c.Int(),
                    })
                .PrimaryKey(t => t.Profile);
            
            CreateTable(
                "dbo.SVs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Alias = c.String(maxLength: 255),
                        Tel = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        ActionType_Id = c.Int(),
                        SV_Id = c.Int(),
                        Year_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActionTypes", t => t.ActionType_Id)
                .ForeignKey("dbo.SVs", t => t.SV_Id)
                .ForeignKey("dbo.Years", t => t.Year_Id)
                .Index(t => t.ActionType_Id)
                .Index(t => t.SV_Id)
                .Index(t => t.Year_Id);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                        StartDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsLock = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Year_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SVs", t => t.SV_Id)
                .ForeignKey("dbo.Years", t => t.Year_Id)
                .Index(t => t.SV_Id)
                .Index(t => t.Year_Id);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Alias = c.String(maxLength: 255),
                        Address_No = c.String(maxLength: 255),
                        Address_Moo = c.String(maxLength: 255),
                        Address_MooBan = c.String(maxLength: 255),
                        Address_Building = c.String(maxLength: 255),
                        Address_Floor = c.String(maxLength: 255),
                        Address_Soi = c.String(maxLength: 255),
                        Address_Road = c.String(maxLength: 255),
                        Address_Tambol_Id = c.Int(nullable: false),
                        Address_Tambol = c.String(maxLength: 255),
                        Address_Amphoe_Id = c.Int(nullable: false),
                        Address_Amphoe = c.String(maxLength: 255),
                        Address_ProvinceCode = c.Int(nullable: false),
                        Address_ZipCode = c.String(maxLength: 5),
                        Address_Latitude = c.Single(nullable: false),
                        Address_Longtitude = c.Single(nullable: false),
                        Address_CreatedBy = c.String(maxLength: 255),
                        Address_CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Address_ModifiedBy = c.String(maxLength: 255),
                        Address_ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Tel = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        ContactPersonName = c.String(maxLength: 255),
                        ConactPersonTel = c.String(maxLength: 255),
                        ContactPersonEmail = c.String(maxLength: 255),
                        HeadPersonName = c.String(maxLength: 255),
                        HeadPersonTel = c.String(maxLength: 255),
                        HeadPersonEmail = c.String(maxLength: 255),
                        Notes = c.String(maxLength: 2048),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SVUnitYear_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SVUnitYears", t => t.SVUnitYear_Id)
                .Index(t => t.SVUnitYear_Id);
            
            CreateTable(
                "dbo.UnitConsults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsEnable = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserInRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastLogin = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        User_Id = c.Int(),
                        UserRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.UserRoles", t => t.UserRole_Id)
                .Index(t => t.User_Id)
                .Index(t => t.UserRole_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        CardId = c.String(maxLength: 13),
                        FullName = c.String(maxLength: 100),
                        Tel = c.String(maxLength: 15),
                        Mobile = c.String(maxLength: 15),
                        Fax = c.String(maxLength: 15),
                        Email = c.String(maxLength: 100),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        isEnable = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserSVs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SV_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SVs", t => t.SV_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.SV_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserUnits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Unit_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Units", t => t.Unit_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Unit_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserUnits", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserUnits", "Unit_Id", "dbo.Units");
            DropForeignKey("dbo.UserSVs", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserSVs", "SV_Id", "dbo.SVs");
            DropForeignKey("dbo.UserInRoles", "UserRole_Id", "dbo.UserRoles");
            DropForeignKey("dbo.UserInRoles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.SVUnitYears", "Year_Id", "dbo.Years");
            DropForeignKey("dbo.Units", "SVUnitYear_Id", "dbo.SVUnitYears");
            DropForeignKey("dbo.SVUnitYears", "SV_Id", "dbo.SVs");
            DropForeignKey("dbo.SVActivityYears", "Year_Id", "dbo.Years");
            DropForeignKey("dbo.UnitActivities", "SVActivityYear_Id", "dbo.SVActivityYears");
            DropForeignKey("dbo.SVActivityYears", "SV_Id", "dbo.SVs");
            DropForeignKey("dbo.SVActivityYears", "ActionType_Id", "dbo.ActionTypes");
            DropForeignKey("dbo.ActualWorks", "TimeTable_Id", "dbo.TimeTables");
            DropForeignKey("dbo.Applicants", "ActualWork_Id", "dbo.ActualWorks");
            DropForeignKey("dbo.Applicants", "UnitActivity_Id", "dbo.UnitActivities");
            DropForeignKey("dbo.Applicants", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Applicants", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.ActualWorks", "ActionType_Id", "dbo.ActionTypes");
            DropIndex("dbo.UserUnits", new[] { "User_Id" });
            DropIndex("dbo.UserUnits", new[] { "Unit_Id" });
            DropIndex("dbo.UserSVs", new[] { "User_Id" });
            DropIndex("dbo.UserSVs", new[] { "SV_Id" });
            DropIndex("dbo.UserInRoles", new[] { "UserRole_Id" });
            DropIndex("dbo.UserInRoles", new[] { "User_Id" });
            DropIndex("dbo.Units", new[] { "SVUnitYear_Id" });
            DropIndex("dbo.SVUnitYears", new[] { "Year_Id" });
            DropIndex("dbo.SVUnitYears", new[] { "SV_Id" });
            DropIndex("dbo.SVActivityYears", new[] { "Year_Id" });
            DropIndex("dbo.SVActivityYears", new[] { "SV_Id" });
            DropIndex("dbo.SVActivityYears", new[] { "ActionType_Id" });
            DropIndex("dbo.UnitActivities", new[] { "SVActivityYear_Id" });
            DropIndex("dbo.Applicants", new[] { "ActualWork_Id" });
            DropIndex("dbo.Applicants", new[] { "UnitActivity_Id" });
            DropIndex("dbo.Applicants", new[] { "Person_Id" });
            DropIndex("dbo.Applicants", new[] { "Company_Id" });
            DropIndex("dbo.ActualWorks", new[] { "TimeTable_Id" });
            DropIndex("dbo.ActualWorks", new[] { "ActionType_Id" });
            DropTable("dbo.UserUnits");
            DropTable("dbo.UserSVs");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.UserInRoles");
            DropTable("dbo.UnitConsults");
            DropTable("dbo.Units");
            DropTable("dbo.SVUnitYears");
            DropTable("dbo.Years");
            DropTable("dbo.SVActivityYears");
            DropTable("dbo.SVs");
            DropTable("dbo.Settings");
            DropTable("dbo.Consultants");
            DropTable("dbo.ApplicantConsults");
            DropTable("dbo.TimeTables");
            DropTable("dbo.UnitActivities");
            DropTable("dbo.People");
            DropTable("dbo.Companies");
            DropTable("dbo.Applicants");
            DropTable("dbo.ActualWorks");
            DropTable("dbo.ActivityTypes");
            DropTable("dbo.ActionTypes");
        }
    }
}
