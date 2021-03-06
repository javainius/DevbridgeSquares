﻿namespace DevbridgeSquares.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedPointstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Points",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoordinateX = c.Int(nullable: false),
                        CoordinateY = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Points");
        }
    }
}
