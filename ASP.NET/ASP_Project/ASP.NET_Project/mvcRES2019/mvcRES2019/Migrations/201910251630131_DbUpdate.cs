namespace mvcRES2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        AgentID = c.Int(nullable: false, identity: true),
                        SIN = c.String(nullable: false, maxLength: 10),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 30),
                        MiddleName = c.String(maxLength: 30),
                        UserName = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 100),
                        Municipality = c.String(nullable: false, maxLength: 30),
                        Province = c.String(nullable: false, maxLength: 30),
                        Country = c.String(nullable: false, maxLength: 30),
                        PostalCode = c.String(nullable: false, maxLength: 30),
                        CellPhoneNumber = c.String(nullable: false, maxLength: 30),
                        BirthDay = c.DateTime(nullable: false),
                        OfficePhoneNumber = c.String(nullable: false, maxLength: 30),
                        HomePhoneNumber = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AgentID);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AgentID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Country = c.String(nullable: false, maxLength: 255, unicode: false),
                        Province = c.String(nullable: false, maxLength: 255, unicode: false),
                        Municipality = c.String(nullable: false, maxLength: 255, unicode: false),
                        Area = c.String(nullable: false, maxLength: 255, unicode: false),
                        PostalCode = c.String(nullable: false, maxLength: 30, unicode: false),
                        NumBeds = c.Int(nullable: false),
                        NumBaths = c.Int(nullable: false),
                        SquareFootage = c.Int(nullable: false),
                        TypeOfHeating = c.String(nullable: false, maxLength: 255, unicode: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Summary = c.String(maxLength: 255, unicode: false),
                        ImageID = c.Int(nullable: false),
                        Signed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Agents", t => t.AgentID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.ImageID, cascadeDelete: true)
                .Index(t => t.AgentID)
                .Index(t => t.CustomerID)
                .Index(t => t.ImageID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        MiddleName = c.String(maxLength: 30),
                        Municipality = c.String(nullable: false, maxLength: 30),
                        Province = c.String(nullable: false, maxLength: 30),
                        Country = c.String(nullable: false, maxLength: 30),
                        PostalCode = c.String(nullable: false, maxLength: 30),
                        PhoneNumber = c.String(nullable: false, maxLength: 30),
                        BirthDay = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImagePath = c.Binary(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ImageID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "ImageID", "dbo.Images");
            DropForeignKey("dbo.Contracts", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Contracts", "AgentID", "dbo.Agents");
            DropIndex("dbo.Contracts", new[] { "ImageID" });
            DropIndex("dbo.Contracts", new[] { "CustomerID" });
            DropIndex("dbo.Contracts", new[] { "AgentID" });
            DropTable("dbo.Images");
            DropTable("dbo.Customers");
            DropTable("dbo.Contracts");
            DropTable("dbo.Agents");
        }
    }
}
