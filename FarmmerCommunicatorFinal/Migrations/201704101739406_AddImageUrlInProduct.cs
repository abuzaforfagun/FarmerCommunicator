namespace FarmmerCommunicatorFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageUrlInProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ImageUrl");
        }
    }
}
