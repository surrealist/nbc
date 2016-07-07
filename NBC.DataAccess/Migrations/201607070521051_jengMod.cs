namespace NBC.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jengMod : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserInRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.UserInRoles", "User_Id", "dbo.Users");
            DropIndex("dbo.UserInRoles", new[] { "Role_Id" });
            DropIndex("dbo.UserInRoles", new[] { "User_Id" });
            AlterColumn("dbo.UserInRoles", "Role_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.UserInRoles", "User_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.UserInRoles", "User_Id");
            CreateIndex("dbo.UserInRoles", "Role_Id");
            AddForeignKey("dbo.UserInRoles", "Role_Id", "dbo.Roles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserInRoles", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInRoles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserInRoles", "Role_Id", "dbo.Roles");
            DropIndex("dbo.UserInRoles", new[] { "Role_Id" });
            DropIndex("dbo.UserInRoles", new[] { "User_Id" });
            AlterColumn("dbo.UserInRoles", "User_Id", c => c.Int());
            AlterColumn("dbo.UserInRoles", "Role_Id", c => c.Int());
            CreateIndex("dbo.UserInRoles", "User_Id");
            CreateIndex("dbo.UserInRoles", "Role_Id");
            AddForeignKey("dbo.UserInRoles", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.UserInRoles", "Role_Id", "dbo.Roles", "Id");
        }
    }
}
