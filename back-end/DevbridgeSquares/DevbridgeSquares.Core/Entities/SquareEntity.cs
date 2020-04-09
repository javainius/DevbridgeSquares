using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DevbridgeSquares.Core.Entities
{
    [Table("Squares")]
    public class SquareEntity
    {
        public int Id { get; set; }
        public PointEntity Point1 { get; set; }
        public PointEntity Point2 { get; set; }
        public PointEntity Point3 { get; set; }
        public PointEntity Point4 { get; set; }
    }
}
