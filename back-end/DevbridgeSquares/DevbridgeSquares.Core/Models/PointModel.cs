using DevbridgeSquares.Core.Enums;

namespace DevbridgeSquares.Core.Models
{
    public class PointModel
    {
        public PointAddingState AddingState { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public PointModel(int coordinateX, int coordinateY)
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
        }
        public PointModel() { }
    }
}
