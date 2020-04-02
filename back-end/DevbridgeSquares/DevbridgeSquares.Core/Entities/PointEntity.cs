using System.ComponentModel.DataAnnotations.Schema;
namespace DevbridgeSquares.Core.Entities
{
    [Table("Points")]
    public class PointEntity
    {
        public int Id { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }

        public PointEntity() { }

        public PointEntity(int coordinateX, int coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }
    }
}
