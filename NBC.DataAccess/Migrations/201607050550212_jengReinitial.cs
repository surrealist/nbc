namespace NBC.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jengReinitial : DbMigration
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
                        ActionManDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ActionType_Id = c.Int(),
                        Applicant_Id = c.Int(),
                        FileAction_Id = c.Int(),
                        FileDailyReport_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActionTypes", t => t.ActionType_Id)
                .ForeignKey("dbo.Applicants", t => t.Applicant_Id)
                .ForeignKey("dbo.FileActions", t => t.FileAction_Id)
                .ForeignKey("dbo.FileDailies", t => t.FileDailyReport_Id)
                .Index(t => t.ActionType_Id)
                .Index(t => t.Applicant_Id)
                .Index(t => t.FileAction_Id)
                .Index(t => t.FileDailyReport_Id);
            
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
                        UnitActivity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .ForeignKey("dbo.UnitActivities", t => t.UnitActivity_Id)
                .Index(t => t.Company_Id)
                .Index(t => t.UnitActivity_Id);
            
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
                        Address_Tambol_Id = c.Int(),
                        Address_TambolName = c.String(maxLength: 255),
                        Address_Amphur_Id = c.Int(),
                        Address_AmphurName = c.String(maxLength: 255),
                        Address_Province_Id = c.Int(),
                        Address_ProvinceName = c.String(maxLength: 255),
                        Address_ZipCode = c.String(maxLength: 5),
                        Address_Latitude = c.Single(),
                        Address_Longtitude = c.Single(),
                        ComCode = c.String(maxLength: 255),
                        BusinessDetail = c.String(maxLength: 2048),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SubBusinessType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MasSubBusinessTypes", t => t.SubBusinessType_Id)
                .Index(t => t.SubBusinessType_Id);
            
            CreateTable(
                "dbo.MasSubBusinessTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        BusinessType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MasBusinessTypes", t => t.BusinessType_Id)
                .Index(t => t.BusinessType_Id);
            
            CreateTable(
                "dbo.MasBusinessTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicantConsultants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Applicant_Id = c.Int(),
                        Consultant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicants", t => t.Applicant_Id)
                .ForeignKey("dbo.Consultants", t => t.Consultant_Id)
                .Index(t => t.Applicant_Id)
                .Index(t => t.Consultant_Id);
            
            CreateTable(
                "dbo.Consultants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Citizenid = c.String(maxLength: 13),
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
                        Address_Tambol_Id = c.Int(),
                        Address_TambolName = c.String(maxLength: 255),
                        Address_Amphur_Id = c.Int(),
                        Address_AmphurName = c.String(maxLength: 255),
                        Address_Province_Id = c.Int(),
                        Address_ProvinceName = c.String(maxLength: 255),
                        Address_ZipCode = c.String(maxLength: 5),
                        Address_Latitude = c.Single(),
                        Address_Longtitude = c.Single(),
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
                "dbo.ApplicantPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsMainPerson = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Applicant_Id = c.Int(),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicants", t => t.Applicant_Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Applicant_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 255),
                        FirstName = c.String(maxLength: 255),
                        SurName = c.String(maxLength: 255),
                        CitizenId = c.String(maxLength: 13),
                        Address_No = c.String(maxLength: 255),
                        Address_Moo = c.String(maxLength: 255),
                        Address_MooBan = c.String(maxLength: 255),
                        Address_Building = c.String(maxLength: 255),
                        Address_Floor = c.String(maxLength: 255),
                        Address_Soi = c.String(maxLength: 255),
                        Address_Road = c.String(maxLength: 255),
                        Address_Tambol_Id = c.Int(),
                        Address_TambolName = c.String(maxLength: 255),
                        Address_Amphur_Id = c.Int(),
                        Address_AmphurName = c.String(maxLength: 255),
                        Address_Province_Id = c.Int(),
                        Address_ProvinceName = c.String(maxLength: 255),
                        Address_ZipCode = c.String(maxLength: 5),
                        Address_Latitude = c.Single(),
                        Address_Longtitude = c.Single(),
                        Mobile = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeqId = c.Int(nullable: false),
                        PlanDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PlanDetail = c.String(maxLength: 2048),
                        PlanManDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ActionType_Id = c.Int(),
                        Applicant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActionTypes", t => t.ActionType_Id)
                .ForeignKey("dbo.Applicants", t => t.Applicant_Id)
                .Index(t => t.ActionType_Id)
                .Index(t => t.Applicant_Id);
            
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
                        Unit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SVActivityYears", t => t.SVActivityYear_Id)
                .ForeignKey("dbo.Units", t => t.Unit_Id)
                .Index(t => t.SVActivityYear_Id)
                .Index(t => t.Unit_Id);
            
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
                "dbo.SVs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Alias = c.String(maxLength: 255),
                        Adress_No = c.String(maxLength: 255),
                        Adress_Moo = c.String(maxLength: 255),
                        Adress_MooBan = c.String(maxLength: 255),
                        Adress_Building = c.String(maxLength: 255),
                        Adress_Floor = c.String(maxLength: 255),
                        Adress_Soi = c.String(maxLength: 255),
                        Adress_Road = c.String(maxLength: 255),
                        Adress_Tambol_Id = c.Int(),
                        Adress_TambolName = c.String(maxLength: 255),
                        Adress_Amphur_Id = c.Int(),
                        Adress_AmphurName = c.String(maxLength: 255),
                        Adress_Province_Id = c.Int(),
                        Adress_ProvinceName = c.String(maxLength: 255),
                        Adress_ZipCode = c.String(maxLength: 5),
                        Adress_Latitude = c.Single(),
                        Adress_Longtitude = c.Single(),
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
                        Unit_Id = c.Int(),
                        Year_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SVs", t => t.SV_Id)
                .ForeignKey("dbo.Units", t => t.Unit_Id)
                .ForeignKey("dbo.Years", t => t.Year_Id)
                .Index(t => t.SV_Id)
                .Index(t => t.Unit_Id)
                .Index(t => t.Year_Id);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactPersonName = c.String(maxLength: 255),
                        ConactPersonTel = c.String(maxLength: 255),
                        ContactPersonEmail = c.String(maxLength: 255),
                        HeadPersonName = c.String(maxLength: 255),
                        HeadPersonTel = c.String(maxLength: 255),
                        HeadPersonEmail = c.String(maxLength: 255),
                        Name = c.String(maxLength: 255),
                        Alias = c.String(maxLength: 255),
                        Adress_No = c.String(maxLength: 255),
                        Adress_Moo = c.String(maxLength: 255),
                        Adress_MooBan = c.String(maxLength: 255),
                        Adress_Building = c.String(maxLength: 255),
                        Adress_Floor = c.String(maxLength: 255),
                        Adress_Soi = c.String(maxLength: 255),
                        Adress_Road = c.String(maxLength: 255),
                        Adress_Tambol_Id = c.Int(),
                        Adress_TambolName = c.String(maxLength: 255),
                        Adress_Amphur_Id = c.Int(),
                        Adress_AmphurName = c.String(maxLength: 255),
                        Adress_Province_Id = c.Int(),
                        Adress_ProvinceName = c.String(maxLength: 255),
                        Adress_ZipCode = c.String(maxLength: 5),
                        Adress_Latitude = c.Single(),
                        Adress_Longtitude = c.Single(),
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
                "dbo.UnitConsults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsEnable = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Consultant_Id = c.Int(),
                        Unit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consultants", t => t.Consultant_Id)
                .ForeignKey("dbo.Units", t => t.Unit_Id)
                .Index(t => t.Consultant_Id)
                .Index(t => t.Unit_Id);
            
            CreateTable(
                "dbo.FileActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        PhysicalLocation = c.String(maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FileDailies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        PhysicalLocation = c.String(maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MasAmphurs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Province_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MasProvinces", t => t.Province_Id)
                .Index(t => t.Province_Id);
            
            CreateTable(
                "dbo.MasProvinces",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MasCareerTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MasEducationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MasTambols",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                        Latitude = c.Single(nullable: false),
                        Longtitude = c.Single(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Amphur_Id = c.Int(),
                        Province_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MasAmphurs", t => t.Amphur_Id)
                .ForeignKey("dbo.MasProvinces", t => t.Province_Id)
                .Index(t => t.Amphur_Id)
                .Index(t => t.Province_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 255),
                        isEnable = c.Boolean(nullable: false),
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
                        MailEnable = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Profile);
            
            CreateTable(
                "dbo.UserInRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        isEnable = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Role_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Role_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        CardId = c.String(maxLength: 13),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Tel = c.String(maxLength: 15),
                        Mobile = c.String(maxLength: 15),
                        Fax = c.String(maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 100),
                        LastLogin = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        isEnable = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInRoles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserInRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.MasTambols", "Province_Id", "dbo.MasProvinces");
            DropForeignKey("dbo.MasTambols", "Amphur_Id", "dbo.MasAmphurs");
            DropForeignKey("dbo.MasAmphurs", "Province_Id", "dbo.MasProvinces");
            DropForeignKey("dbo.ActualWorks", "FileDailyReport_Id", "dbo.FileDailies");
            DropForeignKey("dbo.ActualWorks", "FileAction_Id", "dbo.FileActions");
            DropForeignKey("dbo.Applicants", "UnitActivity_Id", "dbo.UnitActivities");
            DropForeignKey("dbo.UnitActivities", "Unit_Id", "dbo.Units");
            DropForeignKey("dbo.UnitActivities", "SVActivityYear_Id", "dbo.SVActivityYears");
            DropForeignKey("dbo.SVUnitYears", "Year_Id", "dbo.Years");
            DropForeignKey("dbo.SVUnitYears", "Unit_Id", "dbo.Units");
            DropForeignKey("dbo.UnitConsults", "Unit_Id", "dbo.Units");
            DropForeignKey("dbo.UnitConsults", "Consultant_Id", "dbo.Consultants");
            DropForeignKey("dbo.SVUnitYears", "SV_Id", "dbo.SVs");
            DropForeignKey("dbo.SVActivityYears", "Year_Id", "dbo.Years");
            DropForeignKey("dbo.SVActivityYears", "SV_Id", "dbo.SVs");
            DropForeignKey("dbo.SVActivityYears", "ActionType_Id", "dbo.ActionTypes");
            DropForeignKey("dbo.TimeTables", "Applicant_Id", "dbo.Applicants");
            DropForeignKey("dbo.TimeTables", "ActionType_Id", "dbo.ActionTypes");
            DropForeignKey("dbo.ApplicantPersons", "Person_Id", "dbo.People");
            DropForeignKey("dbo.ApplicantPersons", "Applicant_Id", "dbo.Applicants");
            DropForeignKey("dbo.ApplicantConsultants", "Consultant_Id", "dbo.Consultants");
            DropForeignKey("dbo.ApplicantConsultants", "Applicant_Id", "dbo.Applicants");
            DropForeignKey("dbo.Applicants", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Companies", "SubBusinessType_Id", "dbo.MasSubBusinessTypes");
            DropForeignKey("dbo.MasSubBusinessTypes", "BusinessType_Id", "dbo.MasBusinessTypes");
            DropForeignKey("dbo.ActualWorks", "Applicant_Id", "dbo.Applicants");
            DropForeignKey("dbo.ActualWorks", "ActionType_Id", "dbo.ActionTypes");
            DropIndex("dbo.UserInRoles", new[] { "User_Id" });
            DropIndex("dbo.UserInRoles", new[] { "Role_Id" });
            DropIndex("dbo.MasTambols", new[] { "Province_Id" });
            DropIndex("dbo.MasTambols", new[] { "Amphur_Id" });
            DropIndex("dbo.MasAmphurs", new[] { "Province_Id" });
            DropIndex("dbo.UnitConsults", new[] { "Unit_Id" });
            DropIndex("dbo.UnitConsults", new[] { "Consultant_Id" });
            DropIndex("dbo.SVUnitYears", new[] { "Year_Id" });
            DropIndex("dbo.SVUnitYears", new[] { "Unit_Id" });
            DropIndex("dbo.SVUnitYears", new[] { "SV_Id" });
            DropIndex("dbo.SVActivityYears", new[] { "Year_Id" });
            DropIndex("dbo.SVActivityYears", new[] { "SV_Id" });
            DropIndex("dbo.SVActivityYears", new[] { "ActionType_Id" });
            DropIndex("dbo.UnitActivities", new[] { "Unit_Id" });
            DropIndex("dbo.UnitActivities", new[] { "SVActivityYear_Id" });
            DropIndex("dbo.TimeTables", new[] { "Applicant_Id" });
            DropIndex("dbo.TimeTables", new[] { "ActionType_Id" });
            DropIndex("dbo.ApplicantPersons", new[] { "Person_Id" });
            DropIndex("dbo.ApplicantPersons", new[] { "Applicant_Id" });
            DropIndex("dbo.ApplicantConsultants", new[] { "Consultant_Id" });
            DropIndex("dbo.ApplicantConsultants", new[] { "Applicant_Id" });
            DropIndex("dbo.MasSubBusinessTypes", new[] { "BusinessType_Id" });
            DropIndex("dbo.Companies", new[] { "SubBusinessType_Id" });
            DropIndex("dbo.Applicants", new[] { "UnitActivity_Id" });
            DropIndex("dbo.Applicants", new[] { "Company_Id" });
            DropIndex("dbo.ActualWorks", new[] { "FileDailyReport_Id" });
            DropIndex("dbo.ActualWorks", new[] { "FileAction_Id" });
            DropIndex("dbo.ActualWorks", new[] { "Applicant_Id" });
            DropIndex("dbo.ActualWorks", new[] { "ActionType_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.UserInRoles");
            DropTable("dbo.Settings");
            DropTable("dbo.Roles");
            DropTable("dbo.MasTambols");
            DropTable("dbo.MasEducationTypes");
            DropTable("dbo.MasCareerTypes");
            DropTable("dbo.MasProvinces");
            DropTable("dbo.MasAmphurs");
            DropTable("dbo.FileDailies");
            DropTable("dbo.FileActions");
            DropTable("dbo.UnitConsults");
            DropTable("dbo.Units");
            DropTable("dbo.SVUnitYears");
            DropTable("dbo.Years");
            DropTable("dbo.SVs");
            DropTable("dbo.SVActivityYears");
            DropTable("dbo.UnitActivities");
            DropTable("dbo.TimeTables");
            DropTable("dbo.People");
            DropTable("dbo.ApplicantPersons");
            DropTable("dbo.Consultants");
            DropTable("dbo.ApplicantConsultants");
            DropTable("dbo.MasBusinessTypes");
            DropTable("dbo.MasSubBusinessTypes");
            DropTable("dbo.Companies");
            DropTable("dbo.Applicants");
            DropTable("dbo.ActualWorks");
            DropTable("dbo.ActivityTypes");
            DropTable("dbo.ActionTypes");
        }
    }
}
