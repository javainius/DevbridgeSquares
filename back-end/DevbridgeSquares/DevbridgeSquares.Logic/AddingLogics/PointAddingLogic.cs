using DevbridgeSquares.Core.Entities;
using DevbridgeSquares.Core.Enums;
using DevbridgeSquares.Core.Models;
using DevbridgeSquares.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevbridgeSquares.Logic.AddingLogic
{
    public class PointAddingLogic
    {
        private DbPointListState _dbPointList;
        public PointsDTO PointsDTO;
        public DbPointListState AddingDbPointList;
        public PointAddingLogic(List<PointEntity> dbPointList, string pointsInString = null, PointModel point = null)
        {
            _dbPointList = new DbPointListState(dbPointList);
            AddingDbPointList = new DbPointListState();
            PointsDTO = new PointsDTO();

            if (pointsInString != null) FormDTO(pointsInString);
            else PointsDTO.Points.Add(point);
        }

        public void FormDTO(string pointsInString)
        {
            var pointParser = new PointParser(pointsInString);
            PointsDTO.Points = pointParser.GetParsedPoints();
            PointsDTO.UnreadableLinesCount = pointParser.UnreadableLines;
        }

        public void AddPoints()
        {
            foreach(var point in PointsDTO.Points)
            {
                point.AddingState = GetPointAddingState(point.CoordinateX, point.CoordinateY);
                if (point.AddingState == PointAddingState.Added)
                {
                    addPoint(point.CoordinateX, point.CoordinateY);
                } 
            }
        }
        
        public void AddOnePoint()
        {
            PointsDTO.Points.FirstOrDefault().AddingState = GetPointAddingState();
            if (PointsDTO.Points.FirstOrDefault().AddingState == PointAddingState.Added)
            {
                addPoint(PointsDTO.Points.FirstOrDefault().CoordinateX, PointsDTO.Points.FirstOrDefault().CoordinateY);
            } 
        }
        
        private void addPoint(int coordinateX, int coordinateY)
        {
            _dbPointList.AddPoint(new PointEntity()
            {
                CoordinateX = coordinateX,
                CoordinateY = coordinateY
            });
            AddingDbPointList.AddPoint(new PointEntity()
            {
                CoordinateX = coordinateX,
                CoordinateY = coordinateY
            });
        }
        
        public PointAddingState GetPointAddingState(int? coordinateX = null, int? coordinateY = null)
        {
            coordinateX ??= PointsDTO.Points.FirstOrDefault().CoordinateX;
            coordinateY ??= PointsDTO.Points.FirstOrDefault().CoordinateY;

            if(_dbPointList.DoesPointExist(coordinateX, coordinateY))
            {
                return PointAddingState.Duplicate;
            }
            else if(!IsCoordinateAvailable(coordinateX) || !IsCoordinateAvailable(coordinateY))
            {
                return PointAddingState.OutOfRange;
            }
            else if(_dbPointList.AmountOfPoints() >= 10000)
            {
                return PointAddingState.OutOfSpace;
            }
            else
            {
                return PointAddingState.Added;
            }
        }

        public bool IsCoordinateAvailable(int? coordinate) => coordinate >= -5000 && coordinate <= 5000 ? true : false;
    }
}
