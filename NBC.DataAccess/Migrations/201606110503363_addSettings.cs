namespace NBC.DataAccess.Migrations {
  using System;
  using System.Data.Entity.Migrations;

  public partial class addSettings : DbMigration {
    public override void Up() {
      CreateTable(
          "dbo.Settings",
          c => new {
            Profile = c.String(nullable: false, maxLength: 128),
            CurrentYearId = c.Int(),
          })
          .PrimaryKey(t => t.Profile);

    }

    public override void Down() {
      DropTable("dbo.Settings");
    }
  }
}
