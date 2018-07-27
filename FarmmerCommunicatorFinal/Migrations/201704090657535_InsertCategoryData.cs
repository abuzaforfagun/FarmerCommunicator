namespace FarmmerCommunicatorFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertCategoryData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories VALUES ('Rice', 'rice.jpg')");
            Sql("INSERT INTO Categories VALUES ('Mango', 'mango.jpg')");
            Sql("INSERT INTO Categories VALUES ('Wheat', 'wheat.jpg')");
        }
        
        public override void Down()
        {
        }
    }
}
