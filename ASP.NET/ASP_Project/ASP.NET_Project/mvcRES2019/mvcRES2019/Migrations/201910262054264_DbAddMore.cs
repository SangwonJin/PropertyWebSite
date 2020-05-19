namespace mvcRES2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbAddMore : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Agents", "Municipality", c => c.Int(nullable: false));
            AlterColumn("dbo.Agents", "Province", c => c.Int(nullable: false));
            AlterColumn("dbo.Agents", "Country", c => c.Int(nullable: false));
            AlterColumn("dbo.Contracts", "Country", c => c.Int(nullable: false));
            AlterColumn("dbo.Contracts", "Province", c => c.Int(nullable: false));
            AlterColumn("dbo.Contracts", "Municipality", c => c.Int(nullable: false));
            AlterColumn("dbo.Contracts", "Area", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Contracts", "PostalCode", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Contracts", "TypeOfHeating", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Contracts", "Summary", c => c.String(maxLength: 255));
            AlterColumn("dbo.Customers", "Municipality", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Province", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Country", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Country", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Customers", "Province", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Customers", "Municipality", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Contracts", "Summary", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.Contracts", "TypeOfHeating", c => c.String(nullable: false, maxLength: 255, unicode: false));
            AlterColumn("dbo.Contracts", "PostalCode", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.Contracts", "Area", c => c.String(nullable: false, maxLength: 255, unicode: false));
            AlterColumn("dbo.Contracts", "Municipality", c => c.String(nullable: false, maxLength: 255, unicode: false));
            AlterColumn("dbo.Contracts", "Province", c => c.String(nullable: false, maxLength: 255, unicode: false));
            AlterColumn("dbo.Contracts", "Country", c => c.String(nullable: false, maxLength: 255, unicode: false));
            AlterColumn("dbo.Agents", "Country", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Agents", "Province", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Agents", "Municipality", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
