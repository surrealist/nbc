namespace NBC.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YingMasAmTam : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.MasAmphurs", "IX_MasAmphurName");
            DropIndex("dbo.MasTambols", "IX_MasTambolName");
        }
        
        public override void Down()
        {
            CreateIndex("dbo.MasTambols", "Name", unique: true, name: "IX_MasTambolName");
            CreateIndex("dbo.MasAmphurs", "Name", unique: true, name: "IX_MasAmphurName");
        }
    }
}
