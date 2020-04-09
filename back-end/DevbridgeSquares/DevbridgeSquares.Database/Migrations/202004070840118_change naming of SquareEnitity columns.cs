namespace DevbridgeSquares.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changenamingofSquareEnititycolumns : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Squares", name: "Point1Id_Id", newName: "Point1_Id");
            RenameColumn(table: "dbo.Squares", name: "Point2Id_Id", newName: "Point2_Id");
            RenameColumn(table: "dbo.Squares", name: "Point3Id_Id", newName: "Point3_Id");
            RenameColumn(table: "dbo.Squares", name: "Point4Id_Id", newName: "Point4_Id");
            RenameIndex(table: "dbo.Squares", name: "IX_Point1Id_Id", newName: "IX_Point1_Id");
            RenameIndex(table: "dbo.Squares", name: "IX_Point2Id_Id", newName: "IX_Point2_Id");
            RenameIndex(table: "dbo.Squares", name: "IX_Point3Id_Id", newName: "IX_Point3_Id");
            RenameIndex(table: "dbo.Squares", name: "IX_Point4Id_Id", newName: "IX_Point4_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Squares", name: "IX_Point4_Id", newName: "IX_Point4Id_Id");
            RenameIndex(table: "dbo.Squares", name: "IX_Point3_Id", newName: "IX_Point3Id_Id");
            RenameIndex(table: "dbo.Squares", name: "IX_Point2_Id", newName: "IX_Point2Id_Id");
            RenameIndex(table: "dbo.Squares", name: "IX_Point1_Id", newName: "IX_Point1Id_Id");
            RenameColumn(table: "dbo.Squares", name: "Point4_Id", newName: "Point4Id_Id");
            RenameColumn(table: "dbo.Squares", name: "Point3_Id", newName: "Point3Id_Id");
            RenameColumn(table: "dbo.Squares", name: "Point2_Id", newName: "Point2Id_Id");
            RenameColumn(table: "dbo.Squares", name: "Point1_Id", newName: "Point1Id_Id");
        }
    }
}
