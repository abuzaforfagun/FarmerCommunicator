namespace FarmmerCommunicatorFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDealIdInRate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rates", "DealId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rates", "DealId");
            AddForeignKey("dbo.Rates", "DealId", "dbo.Deals", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rates", "DealId", "dbo.Deals");
            DropIndex("dbo.Rates", new[] { "DealId" });
            DropColumn("dbo.Rates", "DealId");
        }
    }
}
