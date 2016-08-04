namespace NBC.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JengCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_ActionTpeName");
            
            CreateTable(
                "dbo.ActivityTypes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(maxLength: 255),
                        ModifiedBy = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_ActivityTypeName");
            
            CreateTable(
                "dbo.ActualWorks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeqId = c.Int(nullable: false),
                        Applicant_Id = c.Int(nullable: false),
                        ActionType_Id = c.Int(nullable: false),
                        ActionDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ActionDetail = c.String(maxLength: 2048),
                        ActionManDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FileAction_Id = c.Int(),
                        FileDailyReport_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActionTypes", t => t.ActionType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Applicants", t => t.Applicant_Id, cascadeDelete: true)
                .ForeignKey("dbo.FileActions", t => t.FileAction_Id)
                .ForeignKey("dbo.FileDailies", t => t.FileDailyReport_Id, cascadeDelete: true)
                .Index(t => t.Applicant_Id, unique: true, name: "IX_ActualWorkApplicant")
                .Index(t => t.ActionType_Id)
                .Index(t => t.FileAction_Id)
                .Index(t => t.FileDailyReport_Id);
            
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company_Id = c.Int(nullable: false),
                        UnitActivity_Id = c.Int(nullable: false),
                        ApplyDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsApproveTimeTable = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id, cascadeDelete: true)
                .ForeignKey("dbo.UnitActivities", t => t.UnitActivity_Id, cascadeDelete: true)
                .Index(t => t.Company_Id)
                .Index(t => t.UnitActivity_Id);
            
            CreateTable(
                "dbo.ApplicantConsultants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Applicant_Id = c.Int(nullable: false),
                        Consultant_Id = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicants", t => t.Applicant_Id, cascadeDelete: true)
                .ForeignKey("dbo.Consultants", t => t.Consultant_Id, cascadeDelete: true)
                .Index(t => t.Applicant_Id)
                .Index(t => t.Consultant_Id);
            
            CreateTable(
                "dbo.Consultants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Citizenid = c.String(nullable: false, maxLength: 13),
                        Title = c.String(maxLength: 255),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        SurName = c.String(nullable: false, maxLength: 255),
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.Citizenid, unique: true, name: "IX_ConsultantCitizenid");
            
            CreateTable(
                "dbo.UnitConsults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Unit_Id = c.Int(nullable: false),
                        Consultant_Id = c.Int(nullable: false),
                        IsEnable = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consultants", t => t.Consultant_Id, cascadeDelete: true)
                .ForeignKey("dbo.WorkPlaces", t => t.Unit_Id, cascadeDelete: true)
                .Index(t => t.Unit_Id)
                .Index(t => t.Consultant_Id);
            
            CreateTable(
                "dbo.WorkPlaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
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
                        ContactPersonName = c.String(maxLength: 255),
                        ConactPersonTel = c.String(maxLength: 255),
                        ContactPersonEmail = c.String(maxLength: 255),
                        HeadPersonName = c.String(maxLength: 255),
                        HeadPersonTel = c.String(maxLength: 255),
                        HeadPersonEmail = c.String(maxLength: 255),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_WorkPlaceName");
            
            CreateTable(
                "dbo.ApplicantPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Applicant_Id = c.Int(nullable: false),
                        Person_Id = c.Int(nullable: false),
                        IsMainPerson = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicants", t => t.Applicant_Id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
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
                        CitizenId = c.String(nullable: false, maxLength: 13),
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.CitizenId, unique: true, name: "IX_PersonCitizenID");
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
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
                .Index(t => t.Name, unique: true, name: "IX_CompanyName")
                .Index(t => t.ComCode, unique: true, name: "IX_CompanyComCode")
                .Index(t => t.SubBusinessType_Id);
            
            CreateTable(
                "dbo.MasSubBusinessTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        MasBusinessType_Id = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MasBusinessTypes", t => t.MasBusinessType_Id, cascadeDelete: true)
                .Index(t => t.Name, unique: true, name: "IX_MasSubBusinessTypeName")
                .Index(t => t.MasBusinessType_Id);
            
            CreateTable(
                "dbo.MasBusinessTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_MasBusinessTypeName");
            
            CreateTable(
                "dbo.TimeTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeqId = c.Int(nullable: false),
                        Applicant_Id = c.Int(nullable: false),
                        ActionType_Id = c.Int(nullable: false),
                        PlanDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PlanDetail = c.String(maxLength: 2048),
                        PlanManDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActionTypes", t => t.ActionType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Applicants", t => t.Applicant_Id, cascadeDelete: true)
                .Index(t => t.Applicant_Id)
                .Index(t => t.ActionType_Id);
            
            CreateTable(
                "dbo.UnitActivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Unit_Id = c.Int(nullable: false),
                        SVActivityYear_Id = c.Int(nullable: false),
                        Target = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SVActivityYears", t => t.SVActivityYear_Id, cascadeDelete: true)
                .ForeignKey("dbo.WorkPlaces", t => t.Unit_Id, cascadeDelete: true)
                .Index(t => t.Name, unique: true, name: "IX_UnitActivityName")
                .Index(t => t.Unit_Id)
                .Index(t => t.SVActivityYear_Id);
            
            CreateTable(
                "dbo.SVActivityYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Target = c.Int(nullable: false),
                        Year_Id = c.Int(nullable: false),
                        ActitivityType_Id = c.String(nullable: false, maxLength: 10),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SV_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityTypes", t => t.ActitivityType_Id, cascadeDelete: true)
                .ForeignKey("dbo.WorkPlaces", t => t.SV_Id)
                .ForeignKey("dbo.Years", t => t.Year_Id, cascadeDelete: true)
                .Index(t => t.Year_Id)
                .Index(t => t.ActitivityType_Id)
                .Index(t => t.SV_Id);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        StartDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsLock = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_YearName");
            
            CreateTable(
                "dbo.SVUnitYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year_Id = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SV_Id = c.Int(),
                        Unit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkPlaces", t => t.SV_Id)
                .ForeignKey("dbo.WorkPlaces", t => t.Unit_Id)
                .ForeignKey("dbo.Years", t => t.Year_Id, cascadeDelete: true)
                .Index(t => t.Year_Id)
                .Index(t => t.SV_Id)
                .Index(t => t.Unit_Id);
            
            CreateTable(
                "dbo.FileActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        PhysicalLocation = c.String(nullable: false, maxLength: 255),
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
                        Name = c.String(nullable: false, maxLength: 255),
                        PhysicalLocation = c.String(nullable: false, maxLength: 255),
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
                        Name = c.String(nullable: false, maxLength: 255),
                        MasProvince_Id = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MasProvinces", t => t.MasProvince_Id, cascadeDelete: true)
                .Index(t => t.Name, unique: true, name: "IX_MasAmphurName")
                .Index(t => t.MasProvince_Id);
            
            CreateTable(
                "dbo.MasProvinces",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_MasProvinceName");
            
            CreateTable(
                "dbo.MasCareerTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_MasCareerTypeName");
            
            CreateTable(
                "dbo.MasEducationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_MasEducationTypeName");
            
            CreateTable(
                "dbo.MasTambols",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        MasAmphur_Id = c.Int(nullable: false),
                        Latitude = c.Single(),
                        Longtitude = c.Single(),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MasAmphurs", t => t.MasAmphur_Id, cascadeDelete: true)
                .Index(t => t.Name, unique: true, name: "IX_MasTambolName")
                .Index(t => t.MasAmphur_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 255),
                        isEnable = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.RoleName, unique: true);
            
            CreateTable(
                "dbo.UserInRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        Role_Id = c.Int(nullable: false),
                        isEnable = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        WorkAt_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.WorkPlaces", t => t.WorkAt_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Role_Id)
                .Index(t => t.WorkAt_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInRoles", "WorkAt_Id", "dbo.WorkPlaces");
            DropForeignKey("dbo.UserInRoles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserInRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.MasTambols", "MasAmphur_Id", "dbo.MasAmphurs");
            DropForeignKey("dbo.MasAmphurs", "MasProvince_Id", "dbo.MasProvinces");
            DropForeignKey("dbo.ActualWorks", "FileDailyReport_Id", "dbo.FileDailies");
            DropForeignKey("dbo.ActualWorks", "FileAction_Id", "dbo.FileActions");
            DropForeignKey("dbo.ActualWorks", "Applicant_Id", "dbo.Applicants");
            DropForeignKey("dbo.Applicants", "UnitActivity_Id", "dbo.UnitActivities");
            DropForeignKey("dbo.UnitActivities", "Unit_Id", "dbo.WorkPlaces");
            DropForeignKey("dbo.UnitActivities", "SVActivityYear_Id", "dbo.SVActivityYears");
            DropForeignKey("dbo.SVActivityYears", "Year_Id", "dbo.Years");
            DropForeignKey("dbo.SVUnitYears", "Year_Id", "dbo.Years");
            DropForeignKey("dbo.SVUnitYears", "Unit_Id", "dbo.WorkPlaces");
            DropForeignKey("dbo.SVUnitYears", "SV_Id", "dbo.WorkPlaces");
            DropForeignKey("dbo.SVActivityYears", "SV_Id", "dbo.WorkPlaces");
            DropForeignKey("dbo.SVActivityYears", "ActitivityType_Id", "dbo.ActivityTypes");
            DropForeignKey("dbo.TimeTables", "Applicant_Id", "dbo.Applicants");
            DropForeignKey("dbo.TimeTables", "ActionType_Id", "dbo.ActionTypes");
            DropForeignKey("dbo.Applicants", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Companies", "SubBusinessType_Id", "dbo.MasSubBusinessTypes");
            DropForeignKey("dbo.MasSubBusinessTypes", "MasBusinessType_Id", "dbo.MasBusinessTypes");
            DropForeignKey("dbo.ApplicantPersons", "Person_Id", "dbo.People");
            DropForeignKey("dbo.ApplicantPersons", "Applicant_Id", "dbo.Applicants");
            DropForeignKey("dbo.ApplicantConsultants", "Consultant_Id", "dbo.Consultants");
            DropForeignKey("dbo.UnitConsults", "Unit_Id", "dbo.WorkPlaces");
            DropForeignKey("dbo.UnitConsults", "Consultant_Id", "dbo.Consultants");
            DropForeignKey("dbo.ApplicantConsultants", "Applicant_Id", "dbo.Applicants");
            DropForeignKey("dbo.ActualWorks", "ActionType_Id", "dbo.ActionTypes");
            DropIndex("dbo.UserInRoles", new[] { "WorkAt_Id" });
            DropIndex("dbo.UserInRoles", new[] { "Role_Id" });
            DropIndex("dbo.UserInRoles", new[] { "User_Id" });
            DropIndex("dbo.Roles", new[] { "RoleName" });
            DropIndex("dbo.MasTambols", new[] { "MasAmphur_Id" });
            DropIndex("dbo.MasTambols", "IX_MasTambolName");
            DropIndex("dbo.MasEducationTypes", "IX_MasEducationTypeName");
            DropIndex("dbo.MasCareerTypes", "IX_MasCareerTypeName");
            DropIndex("dbo.MasProvinces", "IX_MasProvinceName");
            DropIndex("dbo.MasAmphurs", new[] { "MasProvince_Id" });
            DropIndex("dbo.MasAmphurs", "IX_MasAmphurName");
            DropIndex("dbo.SVUnitYears", new[] { "Unit_Id" });
            DropIndex("dbo.SVUnitYears", new[] { "SV_Id" });
            DropIndex("dbo.SVUnitYears", new[] { "Year_Id" });
            DropIndex("dbo.Years", "IX_YearName");
            DropIndex("dbo.SVActivityYears", new[] { "SV_Id" });
            DropIndex("dbo.SVActivityYears", new[] { "ActitivityType_Id" });
            DropIndex("dbo.SVActivityYears", new[] { "Year_Id" });
            DropIndex("dbo.UnitActivities", new[] { "SVActivityYear_Id" });
            DropIndex("dbo.UnitActivities", new[] { "Unit_Id" });
            DropIndex("dbo.UnitActivities", "IX_UnitActivityName");
            DropIndex("dbo.TimeTables", new[] { "ActionType_Id" });
            DropIndex("dbo.TimeTables", new[] { "Applicant_Id" });
            DropIndex("dbo.MasBusinessTypes", "IX_MasBusinessTypeName");
            DropIndex("dbo.MasSubBusinessTypes", new[] { "MasBusinessType_Id" });
            DropIndex("dbo.MasSubBusinessTypes", "IX_MasSubBusinessTypeName");
            DropIndex("dbo.Companies", new[] { "SubBusinessType_Id" });
            DropIndex("dbo.Companies", "IX_CompanyComCode");
            DropIndex("dbo.Companies", "IX_CompanyName");
            DropIndex("dbo.People", "IX_PersonCitizenID");
            DropIndex("dbo.ApplicantPersons", new[] { "Person_Id" });
            DropIndex("dbo.ApplicantPersons", new[] { "Applicant_Id" });
            DropIndex("dbo.WorkPlaces", "IX_WorkPlaceName");
            DropIndex("dbo.UnitConsults", new[] { "Consultant_Id" });
            DropIndex("dbo.UnitConsults", new[] { "Unit_Id" });
            DropIndex("dbo.Consultants", "IX_ConsultantCitizenid");
            DropIndex("dbo.ApplicantConsultants", new[] { "Consultant_Id" });
            DropIndex("dbo.ApplicantConsultants", new[] { "Applicant_Id" });
            DropIndex("dbo.Applicants", new[] { "UnitActivity_Id" });
            DropIndex("dbo.Applicants", new[] { "Company_Id" });
            DropIndex("dbo.ActualWorks", new[] { "FileDailyReport_Id" });
            DropIndex("dbo.ActualWorks", new[] { "FileAction_Id" });
            DropIndex("dbo.ActualWorks", new[] { "ActionType_Id" });
            DropIndex("dbo.ActualWorks", "IX_ActualWorkApplicant");
            DropIndex("dbo.ActivityTypes", "IX_ActivityTypeName");
            DropIndex("dbo.ActionTypes", "IX_ActionTpeName");
            DropTable("dbo.Settings");
            DropTable("dbo.Users");
            DropTable("dbo.UserInRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.MasTambols");
            DropTable("dbo.MasEducationTypes");
            DropTable("dbo.MasCareerTypes");
            DropTable("dbo.MasProvinces");
            DropTable("dbo.MasAmphurs");
            DropTable("dbo.FileDailies");
            DropTable("dbo.FileActions");
            DropTable("dbo.SVUnitYears");
            DropTable("dbo.Years");
            DropTable("dbo.SVActivityYears");
            DropTable("dbo.UnitActivities");
            DropTable("dbo.TimeTables");
            DropTable("dbo.MasBusinessTypes");
            DropTable("dbo.MasSubBusinessTypes");
            DropTable("dbo.Companies");
            DropTable("dbo.People");
            DropTable("dbo.ApplicantPersons");
            DropTable("dbo.WorkPlaces");
            DropTable("dbo.UnitConsults");
            DropTable("dbo.Consultants");
            DropTable("dbo.ApplicantConsultants");
            DropTable("dbo.Applicants");
            DropTable("dbo.ActualWorks");
            DropTable("dbo.ActivityTypes");
            DropTable("dbo.ActionTypes");
        }
    }
}
