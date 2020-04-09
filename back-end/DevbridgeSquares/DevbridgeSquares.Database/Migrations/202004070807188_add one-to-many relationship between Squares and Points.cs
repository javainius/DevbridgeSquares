namespace DevbridgeSquares.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addonetomanyrelationshipbetweenSquaresandPoints : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Squares", "Point1Id_Id", c => c.Int());
            AddColumn("dbo.Squares", "Point2Id_Id", c => c.Int());
            AddColumn("dbo.Squares", "Point3Id_Id", c => c.Int());
            AddColumn("dbo.Squares", "Point4Id_Id", c => c.Int());
            CreateIndex("dbo.Squares", "Point1Id_Id");
            CreateIndex("dbo.Squares", "Point2Id_Id");
            CreateIndex("dbo.Squares", "Point3Id_Id");
            CreateIndex("dbo.Squares", "Point4Id_Id");
            AddForeignKey("dbo.Squares", "Point1Id_Id", "dbo.Points", "Id");
            AddForeignKey("dbo.Squares", "Point2Id_Id", "dbo.Points", "Id");
            AddForeignKey("dbo.Squares", "Point3Id_Id", "dbo.Points", "Id");
            AddForeignKey("dbo.Squares", "Point4Id_Id", "dbo.Points", "Id");
            DropColumn("dbo.Squares", "Point1Id");
            DropColumn("dbo.Squares", "Point2Id");
            DropColumn("dbo.Squares", "Point3Id");
            DropColumn("dbo.Squares", "Point4Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Squares", "Point4Id", c => c.Int(nullable: false));
            AddColumn("dbo.Squares", "Point3Id", c => c.Int(nullable: false));
            AddColumn("dbo.Squares", "Point2Id", c => c.Int(nullable: false));
            AddColumn("dbo.Squares", "Point1Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Squares", "Point4Id_Id", "dbo.Points");
            DropForeignKey("dbo.Squares", "Point3Id_Id", "dbo.Points");
            DropForeignKey("dbo.Squares", "Point2Id_Id", "dbo.Points");
            DropForeignKey("dbo.Squares", "Point1Id_Id", "dbo.Points");
            DropIndex("dbo.Squares", new[] { "Point4Id_Id" });
            DropIndex("dbo.Squares", new[] { "Point3Id_Id" });
            DropIndex("dbo.Squares", new[] { "Point2Id_Id" });
            DropIndex("dbo.Squares", new[] { "Point1Id_Id" });
            DropColumn("dbo.Squares", "Point4Id_Id");
            DropColumn("dbo.Squares", "Point3Id_Id");
            DropColumn("dbo.Squares", "Point2Id_Id");
            DropColumn("dbo.Squares", "Point1Id_Id");
        }
    }
}
