namespace FarmmerCommunicatorFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustRateRatesAndAddRateInProduct : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Rates", new[] { "User_Id" });
            DropColumn("dbo.Rates", "UserId");
            RenameColumn(table: "dbo.Rates", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Rates", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Rates", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Rates", new[] { "UserId" });
            AlterColumn("dbo.Rates", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Rates", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Rates", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rates", "User_Id");
        }
    }
}
