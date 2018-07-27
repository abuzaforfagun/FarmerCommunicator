namespace FarmmerCommunicatorFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFarmerIdProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "FarmerId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "FarmerId");
        }
    }
}
