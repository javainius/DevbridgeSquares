using DevbridgeSquares.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevbridgeSquares.Core.Models
{
    public class SquareModel : IEquatable<SquareModel>
    {
        public PointModel[] Points { get; set; }
        public SquareModel() { }
        public SquareModel(PointModel point1,
                           PointModel point2,
                           PointModel point3,
                           PointModel point4)
        {
            Points = new PointModel[4];
            Points[0] = point1;
            Points[1] = point2;
            Points[2] = point3;
            Points[3] = point4;
        }
        public bool Equals(SquareModel other)
        {
            if (other is null)
                return false;

            return Points.SequenceEqual(other.Points);
        }

        public override bool Equals(object obj) => Equals(obj as SquareModel);
        public override int GetHashCode() => (Points).GetHashCode();
    }
}
