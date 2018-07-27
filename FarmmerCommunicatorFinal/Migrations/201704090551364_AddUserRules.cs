namespace FarmmerCommunicatorFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserRules : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into AspNetRoles VALUES (1, 'Farmer')");
            Sql("Insert into AspNetRoles VALUES (2, 'Buyer')");
        }
        
        public override void Down()
        {
        }
    }
}
