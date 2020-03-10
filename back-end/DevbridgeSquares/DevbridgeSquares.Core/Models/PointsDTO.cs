using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevbridgeSquares.Core.Models
{
    public class PointsDTO
    {
        public List<PointModel> Points { get; set; }
        public int UnreadableLinesCount { get; set; }

        public PointsDTO()
        {
            Points = new List<PointModel>();
        }
    }
}
