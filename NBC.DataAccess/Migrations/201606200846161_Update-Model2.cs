namespace NBC.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel2 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UnitConsults");
            DropTable("dbo.ApplicantConsults");
            DropTable("dbo.ActivityTypes");
        }
    }
}
