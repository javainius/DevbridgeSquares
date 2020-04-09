using DevbridgeSquares.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DevbridgeSquares.Logic.DbItemCopies
{
    public class DbPointsCopy
    {
        public List<PointEntity> DbPoints { get; set; }

        public DbPointsCopy(List<PointEntity> dbPointList)
        {
            DbPoints = dbPointList;
        }

        public DbPointsCopy()
        {
            DbPoints = new List<PointEntity>();
        }

        public bool DoesPointExist(int coordinateX, int coordinateY)
        {
            return DbPoints.ToList().Exists(point =>
                    point.CoordinateX.Equals(coordinateX) &&
                    point.CoordinateY.Equals(coordinateY));
        }

        public int AmountOfPoints() => DbPoints.Count();

        public void AddPoint(PointEntity point) => DbPoints.Add(point);
    }
}
