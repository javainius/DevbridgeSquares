using DevbridgeSquares.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DevbridgeSquares.Database.Contexts
{
    public class MainContext : DbContext
    {
        public DbSet<PointEntity> Points { get; set; }
        public DbSet<SquareEntity> Squares { get; set; }
        public MainContext()
            : base("data source = (localdb)\\MSSQLLocalDB; Initial Catalog = DevbridgeSquares; integrated security = SSPI")
        {
        }
    }
}
