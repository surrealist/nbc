namespace NBC.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modVer1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Settings");
            AddColumn("dbo.Settings", "Profile", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Settings", "CurrentYearId", c => c.Int());
            AddPrimaryKey("dbo.Settings", "Profile");
            DropColumn("dbo.Settings", "Id");
            DropColumn("dbo.Settings", "Key");
            DropColumn("dbo.Settings", "Value");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Settings", "Value", c => c.Int(nullable: false));
            AddColumn("dbo.Settings", "Key", c => c.String());
            AddColumn("dbo.Settings", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Settings");
            DropColumn("dbo.Settings", "CurrentYearId");
            DropColumn("dbo.Settings", "Profile");
            AddPrimaryKey("dbo.Settings", "Id");
        }
    }
}
