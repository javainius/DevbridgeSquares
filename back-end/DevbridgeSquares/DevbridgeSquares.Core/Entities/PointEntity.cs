using System.ComponentModel.DataAnnotations.Schema;
namespace DevbridgeSquares.Core.Entities
{
    [Table("Points")]
    public class PointEntity
    {
        public int Id { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
    }
}
