using DevbridgeSquares.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevbridgeSquares.Database.Contexts
{
    public class MainContext : DbContext
    {
        private volatile Type _dependency;
        public DbSet<PointEntity> Points { get; set; }
        public MainContext()
            : base("name = DefaultConnection")
        {
            _dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }
    }
}
