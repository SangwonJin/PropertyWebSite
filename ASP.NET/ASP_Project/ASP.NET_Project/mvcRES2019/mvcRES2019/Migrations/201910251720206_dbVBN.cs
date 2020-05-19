namespace mvcRES2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbVBN : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.CityID);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceID = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(),
                    })
                .PrimaryKey(t => t.ProvinceID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Provinces");
            DropTable("dbo.Cities");
        }
    }
}
