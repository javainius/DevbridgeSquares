namespace DevbridgeSquares.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSquarestable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Squares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Point1Id = c.Int(nullable: false),
                        Point2Id = c.Int(nullable: false),
                        Point3Id = c.Int(nullable: false),
                        Point4Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Squares");
        }
    }
}
