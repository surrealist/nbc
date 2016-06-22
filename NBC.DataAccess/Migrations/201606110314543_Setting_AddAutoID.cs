namespace NBC.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Setting_AddAutoID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Settings");
            AlterColumn("dbo.Settings", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Settings", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Settings");
            AlterColumn("dbo.Settings", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Settings", "Id");
        }
    }
}
