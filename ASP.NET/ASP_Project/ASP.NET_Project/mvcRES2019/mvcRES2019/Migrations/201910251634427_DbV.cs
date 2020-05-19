namespace mvcRES2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbV : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agents", "ImagePath", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agents", "ImagePath");
        }
    }
}
