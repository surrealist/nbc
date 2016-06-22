namespace NBC.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JengModified : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ActionTypes");
            DropPrimaryKey("dbo.ActualWorks");
            DropPrimaryKey("dbo.Applicants");
            DropPrimaryKey("dbo.Companies");
            DropPrimaryKey("dbo.Consultants");
            DropPrimaryKey("dbo.People");
            DropPrimaryKey("dbo.SVs");
            DropPrimaryKey("dbo.TimeTables");
            DropPrimaryKey("dbo.Units");
            CreateTable(
                "dbo.UnitActivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Target = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Applicants", "Company_Id", c => c.Int());
            AddColumn("dbo.Applicants", "Person_Id", c => c.Int());
            AddColumn("dbo.Applicants", "UnitActivity_Id", c => c.Int());
            AlterColumn("dbo.ActionTypes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ActualWorks", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Applicants", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Companies", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Consultants", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.People", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.SVs", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.TimeTables", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Units", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ActionTypes", "Id");
            AddPrimaryKey("dbo.ActualWorks", "Id");
            AddPrimaryKey("dbo.Applicants", "Id");
            AddPrimaryKey("dbo.Companies", "Id");
            AddPrimaryKey("dbo.Consultants", "Id");
            AddPrimaryKey("dbo.People", "Id");
            AddPrimaryKey("dbo.SVs", "Id");
            AddPrimaryKey("dbo.TimeTables", "Id");
            AddPrimaryKey("dbo.Units", "Id");
            CreateIndex("dbo.Applicants", "Company_Id");
            CreateIndex("dbo.Applicants", "Person_Id");
            CreateIndex("dbo.Applicants", "UnitActivity_Id");
            AddForeignKey("dbo.Applicants", "Company_Id", "dbo.Companies", "Id");
            AddForeignKey("dbo.Applicants", "Person_Id", "dbo.People", "Id");
            AddForeignKey("dbo.Applicants", "UnitActivity_Id", "dbo.UnitActivities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applicants", "UnitActivity_Id", "dbo.UnitActivities");
            DropForeignKey("dbo.Applicants", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Applicants", "Company_Id", "dbo.Companies");
            DropIndex("dbo.Applicants", new[] { "UnitActivity_Id" });
            DropIndex("dbo.Applicants", new[] { "Person_Id" });
            DropIndex("dbo.Applicants", new[] { "Company_Id" });
            DropPrimaryKey("dbo.Units");
            DropPrimaryKey("dbo.TimeTables");
            DropPrimaryKey("dbo.SVs");
            DropPrimaryKey("dbo.People");
            DropPrimaryKey("dbo.Consultants");
            DropPrimaryKey("dbo.Companies");
            DropPrimaryKey("dbo.Applicants");
            DropPrimaryKey("dbo.ActualWorks");
            DropPrimaryKey("dbo.ActionTypes");
            AlterColumn("dbo.Units", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.TimeTables", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.SVs", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.People", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Consultants", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Companies", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Applicants", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ActualWorks", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ActionTypes", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Applicants", "UnitActivity_Id");
            DropColumn("dbo.Applicants", "Person_Id");
            DropColumn("dbo.Applicants", "Company_Id");
            DropTable("dbo.UnitActivities");
            AddPrimaryKey("dbo.Units", "Id");
            AddPrimaryKey("dbo.TimeTables", "Id");
            AddPrimaryKey("dbo.SVs", "Id");
            AddPrimaryKey("dbo.People", "Id");
            AddPrimaryKey("dbo.Consultants", "Id");
            AddPrimaryKey("dbo.Companies", "Id");
            AddPrimaryKey("dbo.Applicants", "Id");
            AddPrimaryKey("dbo.ActualWorks", "Id");
            AddPrimaryKey("dbo.ActionTypes", "Id");
        }
    }
}
