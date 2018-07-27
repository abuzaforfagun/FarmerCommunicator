namespace FarmmerCommunicatorFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusInDeal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deals", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Deals", "Status");
        }
    }
}
