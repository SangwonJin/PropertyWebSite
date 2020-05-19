namespace mvcRES2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbVew : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Cities");
            DropTable("dbo.Countries");
            DropTable("dbo.Provinces");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceID = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(),
                    })
                .PrimaryKey(t => t.ProvinceID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.CityID);
            
        }
    }
}
