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
            Point.AddingState = GetPointAddingState();
        } 

        public PointAddingState GetPointAddingState()
        {
            if (_dbPointList.DoesPointExist(Point.CoordinateX, Point.CoordinateY))
            {
                return PointAddingState.Duplicate;
            }
            else if (!IsCoordinateAvailable(Point.CoordinateX) || !IsCoordinateAvailable(Point.CoordinateY))
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
