namespace NBC.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Address_No", c => c.String(maxLength: 255));
            AddColumn("dbo.Companies", "Address_Moo", c => c.String(maxLength: 255));
            AddColumn("dbo.Companies", "Address_MooBan", c => c.String(maxLength: 255));
            AddColumn("dbo.Companies", "Address_Building", c => c.String(maxLength: 255));
            AddColumn("dbo.Companies", "Address_Floor", c => c.String(maxLength: 255));
            AddColumn("dbo.Companies", "Address_Soi", c => c.String(maxLength: 255));
            AddColumn("dbo.Companies", "Address_Road", c => c.String(maxLength: 255));
            AddColumn("dbo.Companies", "Address_Tambol_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Companies", "Address_Tambol", c => c.String(maxLength: 255));
            AddColumn("dbo.Companies", "Address_Amphoe_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Companies", "Address_Amphoe", c => c.String(maxLength: 255));
            AddColumn("dbo.Companies", "Address_ProvinceCode", c => c.Int(nullable: false));
            AddColumn("dbo.Companies", "Address_ZipCode", c => c.String(maxLength: 5));
            AddColumn("dbo.Companies", "Address_Latitude", c => c.Single(nullable: false));
            AddColumn("dbo.Companies", "Address_Longtitude", c => c.Single(nullable: false));
            AddColumn("dbo.Consultants", "Address_No", c => c.String(maxLength: 255));
            AddColumn("dbo.Consultants", "Address_Moo", c => c.String(maxLength: 255));
            AddColumn("dbo.Consultants", "Address_MooBan", c => c.String(maxLength: 255));
            AddColumn("dbo.Consultants", "Address_Building", c => c.String(maxLength: 255));
            AddColumn("dbo.Consultants", "Address_Floor", c => c.String(maxLength: 255));
            AddColumn("dbo.Consultants", "Address_Soi", c => c.String(maxLength: 255));
            AddColumn("dbo.Consultants", "Address_Road", c => c.String(maxLength: 255));
            AddColumn("dbo.Consultants", "Address_Tambol_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Consultants", "Address_Tambol", c => c.String(maxLength: 255));
            AddColumn("dbo.Consultants", "Address_Amphoe_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Consultants", "Address_Amphoe", c => c.String(maxLength: 255));
            AddColumn("dbo.Consultants", "Address_ProvinceCode", c => c.Int(nullable: false));
            AddColumn("dbo.Consultants", "Address_ZipCode", c => c.String(maxLength: 5));
            AddColumn("dbo.Consultants", "Address_Latitude", c => c.Single(nullable: false));
            AddColumn("dbo.Consultants", "Address_Longtitude", c => c.Single(nullable: false));
            AddColumn("dbo.People", "Address_No", c => c.String(maxLength: 255));
            AddColumn("dbo.People", "Address_Moo", c => c.String(maxLength: 255));
            AddColumn("dbo.People", "Address_MooBan", c => c.String(maxLength: 255));
            AddColumn("dbo.People", "Address_Building", c => c.String(maxLength: 255));
            AddColumn("dbo.People", "Address_Floor", c => c.String(maxLength: 255));
            AddColumn("dbo.People", "Address_Soi", c => c.String(maxLength: 255));
            AddColumn("dbo.People", "Address_Road", c => c.String(maxLength: 255));
            AddColumn("dbo.People", "Address_Tambol_Id", c => c.Int(nullable: false));
            AddColumn("dbo.People", "Address_Tambol", c => c.String(maxLength: 255));
            AddColumn("dbo.People", "Address_Amphoe_Id", c => c.Int(nullable: false));
            AddColumn("dbo.People", "Address_Amphoe", c => c.String(maxLength: 255));
            AddColumn("dbo.People", "Address_ProvinceCode", c => c.Int(nullable: false));
            AddColumn("dbo.People", "Address_ZipCode", c => c.String(maxLength: 5));
            AddColumn("dbo.People", "Address_Latitude", c => c.Single(nullable: false));
            AddColumn("dbo.People", "Address_Longtitude", c => c.Single(nullable: false));
            AddColumn("dbo.Units", "Adress_No", c => c.String(maxLength: 255));
            AddColumn("dbo.Units", "Adress_Moo", c => c.String(maxLength: 255));
            AddColumn("dbo.Units", "Adress_MooBan", c => c.String(maxLength: 255));
            AddColumn("dbo.Units", "Adress_Building", c => c.String(maxLength: 255));
            AddColumn("dbo.Units", "Adress_Floor", c => c.String(maxLength: 255));
            AddColumn("dbo.Units", "Adress_Soi", c => c.String(maxLength: 255));
            AddColumn("dbo.Units", "Adress_Road", c => c.String(maxLength: 255));
            AddColumn("dbo.Units", "Adress_Tambol_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Units", "Adress_Tambol", c => c.String(maxLength: 255));
            AddColumn("dbo.Units", "Adress_Amphoe_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Units", "Adress_Amphoe", c => c.String(maxLength: 255));
            AddColumn("dbo.Units", "Adress_ProvinceCode", c => c.Int(nullable: false));
            AddColumn("dbo.Units", "Adress_ZipCode", c => c.String(maxLength: 5));
            AddColumn("dbo.Units", "Adress_Latitude", c => c.Single(nullable: false));
            AddColumn("dbo.Units", "Adress_Longtitude", c => c.Single(nullable: false));
            DropColumn("dbo.Companies", "Address");
            DropColumn("dbo.Consultants", "Address");
            DropColumn("dbo.People", "Address");
            DropColumn("dbo.Units", "Adress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Units", "Adress", c => c.String());
            AddColumn("dbo.People", "Address", c => c.String());
            AddColumn("dbo.Consultants", "Address", c => c.String());
            AddColumn("dbo.Companies", "Address", c => c.String());
            DropColumn("dbo.Units", "Adress_Longtitude");
            DropColumn("dbo.Units", "Adress_Latitude");
            DropColumn("dbo.Units", "Adress_ZipCode");
            DropColumn("dbo.Units", "Adress_ProvinceCode");
            DropColumn("dbo.Units", "Adress_Amphoe");
            DropColumn("dbo.Units", "Adress_Amphoe_Id");
            DropColumn("dbo.Units", "Adress_Tambol");
            DropColumn("dbo.Units", "Adress_Tambol_Id");
            DropColumn("dbo.Units", "Adress_Road");
            DropColumn("dbo.Units", "Adress_Soi");
            DropColumn("dbo.Units", "Adress_Floor");
            DropColumn("dbo.Units", "Adress_Building");
            DropColumn("dbo.Units", "Adress_MooBan");
            DropColumn("dbo.Units", "Adress_Moo");
            DropColumn("dbo.Units", "Adress_No");
            DropColumn("dbo.People", "Address_Longtitude");
            DropColumn("dbo.People", "Address_Latitude");
            DropColumn("dbo.People", "Address_ZipCode");
            DropColumn("dbo.People", "Address_ProvinceCode");
            DropColumn("dbo.People", "Address_Amphoe");
            DropColumn("dbo.People", "Address_Amphoe_Id");
            DropColumn("dbo.People", "Address_Tambol");
            DropColumn("dbo.People", "Address_Tambol_Id");
            DropColumn("dbo.People", "Address_Road");
            DropColumn("dbo.People", "Address_Soi");
            DropColumn("dbo.People", "Address_Floor");
            DropColumn("dbo.People", "Address_Building");
            DropColumn("dbo.People", "Address_MooBan");
            DropColumn("dbo.People", "Address_Moo");
            DropColumn("dbo.People", "Address_No");
            DropColumn("dbo.Consultants", "Address_Longtitude");
            DropColumn("dbo.Consultants", "Address_Latitude");
            DropColumn("dbo.Consultants", "Address_ZipCode");
            DropColumn("dbo.Consultants", "Address_ProvinceCode");
            DropColumn("dbo.Consultants", "Address_Amphoe");
            DropColumn("dbo.Consultants", "Address_Amphoe_Id");
            DropColumn("dbo.Consultants", "Address_Tambol");
            DropColumn("dbo.Consultants", "Address_Tambol_Id");
            DropColumn("dbo.Consultants", "Address_Road");
            DropColumn("dbo.Consultants", "Address_Soi");
            DropColumn("dbo.Consultants", "Address_Floor");
            DropColumn("dbo.Consultants", "Address_Building");
            DropColumn("dbo.Consultants", "Address_MooBan");
            DropColumn("dbo.Consultants", "Address_Moo");
            DropColumn("dbo.Consultants", "Address_No");
            DropColumn("dbo.Companies", "Address_Longtitude");
            DropColumn("dbo.Companies", "Address_Latitude");
            DropColumn("dbo.Companies", "Address_ZipCode");
            DropColumn("dbo.Companies", "Address_ProvinceCode");
            DropColumn("dbo.Companies", "Address_Amphoe");
            DropColumn("dbo.Companies", "Address_Amphoe_Id");
            DropColumn("dbo.Companies", "Address_Tambol");
            DropColumn("dbo.Companies", "Address_Tambol_Id");
            DropColumn("dbo.Companies", "Address_Road");
            DropColumn("dbo.Companies", "Address_Soi");
            DropColumn("dbo.Companies", "Address_Floor");
            DropColumn("dbo.Companies", "Address_Building");
            DropColumn("dbo.Companies", "Address_MooBan");
            DropColumn("dbo.Companies", "Address_Moo");
            DropColumn("dbo.Companies", "Address_No");
        }
    }
}
