namespace NBC.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unit_AddClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Key = c.String(),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 100),
                        Alias = c.String(),
                        Adress = c.String(),
                        Tel = c.String(maxLength: 15),
                        Email = c.String(maxLength: 30),
                        ContactPersonName = c.String(maxLength: 100),
                        ConactPersonTel = c.String(maxLength: 15),
                        ContactPersonEmail = c.String(maxLength: 30),
                        HeadPersonName = c.String(maxLength: 100),
                        HeadPersonTel = c.String(maxLength: 15),
                        HeadPersonEmail = c.String(maxLength: 30),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Units");
            DropTable("dbo.Settings");
        }
    }
}
