namespace FarmmerCommunicatorFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyBuyerRequestDAte : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BuyerRequests", "AddedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BuyerRequests", "AddedDate", c => c.String());
        }
    }
}
