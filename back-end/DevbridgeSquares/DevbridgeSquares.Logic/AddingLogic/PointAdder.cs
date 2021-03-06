﻿using DevbridgeSquares.Core.Entities;
using DevbridgeSquares.Core.Enums;
using DevbridgeSquares.Core.Models;
using DevbridgeSquares.Logic.DbItemCopies;
using System.Collections.Generic;

namespace DevbridgeSquares.Logic.AddingLogic
{
    public class PointAdder
    {
        private DbPointsCopy _dbPointList;
        public PointModel Point;
        public PointAdder(List<PointEntity> dbPointList)
        {
            _dbPointList = new DbPointsCopy(dbPointList);
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
