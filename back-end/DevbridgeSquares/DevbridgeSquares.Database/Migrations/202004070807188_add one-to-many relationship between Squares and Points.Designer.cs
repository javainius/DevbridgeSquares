﻿// <auto-generated />
namespace DevbridgeSquares.Database.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.4.0")]
    public sealed partial class addonetomanyrelationshipbetweenSquaresandPoints : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(addonetomanyrelationshipbetweenSquaresandPoints));
        
        string IMigrationMetadata.Id
        {
            get { return "202004070807188_add one-to-many relationship between Squares and Points"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
