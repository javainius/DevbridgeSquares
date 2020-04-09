using DevbridgeSquares.Core.Enums;
using System;

namespace DevbridgeSquares.Core.Models
{
    public class PointModel : IEquatable<PointModel>
    {
        public PointAddingState AddingState { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public int Id { get; set; }
        public PointModel(int coordinateX, int coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }
        public PointModel() { }

        public bool Equals(PointModel other)
        {
            if (other is null)
                return false;

            return CoordinateX == other.CoordinateX &&
                CoordinateY == other.CoordinateY &&
                Id == other.Id;
        }

        public override bool Equals(object obj) => Equals(obj as PointModel);
        public override int GetHashCode() => (CoordinateX, CoordinateY).GetHashCode();
    }
}
