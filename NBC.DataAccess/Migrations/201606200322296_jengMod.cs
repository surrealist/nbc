namespace NBC.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jengMod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Years", "IsLock", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Years", "IsLock");
        }
    }
}
