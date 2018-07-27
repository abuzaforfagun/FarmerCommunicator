namespace FarmmerCommunicatorFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFarmerObjectInProduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "FarmerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Products", "FarmerId");
            AddForeignKey("dbo.Products", "FarmerId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "FarmerId", "dbo.AspNetUsers");
            DropIndex("dbo.Products", new[] { "FarmerId" });
            AlterColumn("dbo.Products", "FarmerId", c => c.String());
        }
    }
}
