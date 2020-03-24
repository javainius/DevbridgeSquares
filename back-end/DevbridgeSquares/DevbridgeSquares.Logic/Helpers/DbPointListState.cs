using DevbridgeSquares.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DevbridgeSquares.Logic.Helpers
{
    public class DbPointListState
    {
        public List<PointEntity> DbPointList { get; set; }

        public DbPointListState(List<PointEntity> dbPointList)
        {
            DbPointList = dbPointList;
        }

        public DbPointListState()
        {
            DbPointList = new List<PointEntity>();
        }

        public bool DoesPointExist(int coordinateX, int coordinateY)
        {
            return DbPointList.ToList().Exists(point =>
                    point.CoordinateX.Equals(coordinateX) &&
                    point.CoordinateY.Equals(coordinateY));
        }

        public int AmountOfPoints() => DbPointList.Count();

        public void AddPoint(PointEntity point) => DbPointList.Add(point);
    }
}
