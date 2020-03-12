using DevbridgeSquares.Core.Entities;
using DevbridgeSquares.Core.Enums;
using DevbridgeSquares.Core.Models;
using DevbridgeSquares.Logic.Helpers;
using System.Collections.Generic;

namespace DevbridgeSquares.Logic.AddingLogic
{
    public class PointAddingLogic
    {
        private DbPointListState _dbPointList;
        public PointModel Point;
        public PointAddingLogic(List<PointEntity> dbPointList)
        {
            _dbPointList = new DbPointListState(dbPointList);
        }

        public void ProcessPoint(PointModel point) 
        {
            Point = point;
            Point.AddingState = GetPointAddingState(point);
        } 

        public PointAddingState GetPointAddingState(PointModel point)
        {
            int coordinateX = point.CoordinateX;
            int coordinateY = point.CoordinateY;

            if (_dbPointList.DoesPointExist(coordinateX, coordinateY))
            {
                return PointAddingState.Duplicate;
            }
            else if (!IsCoordinateAvailable(coordinateX) || !IsCoordinateAvailable(coordinateY))
            {
                return PointAddingState.OutOfRange;
            }
            else if (_dbPointList.AmountOfPoints() >= 10000)
            {
                return PointAddingState.OutOfSpace;
            }
            else
            {
                return PointAddingState.Added;
            }
        }

        public bool IsCoordinateAvailable(int coordinate) => coordinate >= -5000 && coordinate <= 5000 ? true : false;
    }
}
