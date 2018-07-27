namespace FarmmerCommunicatorFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBuyerObjectInDeal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Deals", "FarmerId", c => c.String());
            AlterColumn("dbo.Deals", "BuyerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Deals", "BuyerId");
            AddForeignKey("dbo.Deals", "BuyerId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deals", "BuyerId", "dbo.AspNetUsers");
            DropIndex("dbo.Deals", new[] { "BuyerId" });
            AlterColumn("dbo.Deals", "BuyerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Deals", "FarmerId", c => c.Int(nullable: false));
        }
    }
}
