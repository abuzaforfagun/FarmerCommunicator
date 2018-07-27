namespace FarmmerCommunicatorFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        FarmerId = c.Int(nullable: false),
                        BuyerId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deals", "ProductId", "dbo.Products");
            DropIndex("dbo.Deals", new[] { "ProductId" });
            DropTable("dbo.Deals");
        }
    }
}
