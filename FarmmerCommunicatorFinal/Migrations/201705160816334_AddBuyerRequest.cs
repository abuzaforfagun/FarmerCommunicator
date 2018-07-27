namespace FarmmerCommunicatorFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBuyerRequest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuyerRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        BuyerId = c.String(maxLength: 128),
                        Title = c.String(),
                        Description = c.String(),
                        AddedDate = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.BuyerId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.BuyerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuyerRequests", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.BuyerRequests", "BuyerId", "dbo.AspNetUsers");
            DropIndex("dbo.BuyerRequests", new[] { "BuyerId" });
            DropIndex("dbo.BuyerRequests", new[] { "CategoryId" });
            DropTable("dbo.BuyerRequests");
        }
    }
}
