using System;
using System.Collections.Generic;
using System.Text;

namespace DevbridgeSquares.Core.ViewModels
{
    public class SquareView
    {
        public int Id { get; set; }
        public PointView Point1 { get; set; }
        public PointView Point2 { get; set; }
        public PointView Point3 { get; set; }
        public PointView Point4 { get; set; }
    }
}
