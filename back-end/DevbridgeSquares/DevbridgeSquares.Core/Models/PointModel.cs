using DevbridgeSquares.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevbridgeSquares.Core.Models
{
    public class PointModel
    {
        public PointAddingState AddingState { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public PointModel(int coordinateX, int coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }
    }
}
