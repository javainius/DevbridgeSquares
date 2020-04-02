using DevbridgeSquares.Core.Entities;
using DevbridgeSquares.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevbridgeSquares.Logic.FindingLogic
{
    public class SquareCalculator
    {
        public List<PointModel> Points { get; set; }
        public List<SquareModel> Squares { get; set; }

        public SquareCalculator(List<PointModel> points)
        {
            Points = points;
            Squares = new List<SquareModel>();
        }

        public List<SquareModel> GetSquares()
        {
            RemovePointsWithoutPairs();

            for (int i = 0; i < Points.Count(); i++)
            {
                for (int j = i + 1; j < Points.Count(); j++)
                {
                    if (Points[i].CoordinateY == Points[j].CoordinateY)
                    {
                        ProcessTheLine(Points[i], Points[j]);
                    }
                }
            }

            return Squares;
        }

        public void ProcessTheLine(PointModel point1, PointModel point2)
        {
            int length = GetLengthBetweenPoints(point1.CoordinateX, point2.CoordinateX);

            var potentialLine = GetUpperLine(point1, point2, length);
            AddSquareIfPotentialLineExists(point1, point2, potentialLine);

            potentialLine = GetLowerLine(point1, point2, length);
            AddSquareIfPotentialLineExists(point1, point2, potentialLine);
        }

        public void RemovePointsWithoutPairs()
        {
            Points = Points.GroupBy(point => point.CoordinateX)
                                     .Where(point => point.Count() > 1)
                                     .SelectMany(point => point).ToList();
            Points = Points.GroupBy(point => point.CoordinateY)
                                     .Where(point => point.Count() > 1)
                                     .SelectMany(point => point).ToList();
            Points = Points.GroupBy(point => point.CoordinateX)
                                     .Where(point => point.Count() > 1)
                                     .SelectMany(point => point).ToList();
        }

        public void AddSquareIfPotentialLineExists(PointModel point1, PointModel point2, List<PointModel> potentialLine)
        {
            if (DoesLineExist(potentialLine))
            {
                var newSquare = new SquareModel(point1, point2, potentialLine[0], potentialLine[1]);
                newSquare.Points = newSquare.Points.OrderBy(point => point.CoordinateY).ToArray();
                newSquare.Points = newSquare.Points.OrderBy(point => point.CoordinateX).ToArray();

                if (!WasSquareAdded(newSquare))
                    Squares.Add(newSquare);
            }
        }

        public List<PointModel> GetUpperLine(PointModel point1, PointModel point2, int height)
        {
            return new List<PointModel>
            {
                new PointModel
                {
                    CoordinateX = point1.CoordinateX,
                    CoordinateY = point1.CoordinateY + height
                },
                new PointModel
                {
                    CoordinateX = point2.CoordinateX,
                    CoordinateY = point2.CoordinateY + height
                }
            };
        }

        public List<PointModel> GetLowerLine(PointModel point1, PointModel point2, int height)
        {
            return new List<PointModel>
            {
                new PointModel
                {
                    CoordinateX = point1.CoordinateX,
                    CoordinateY = point1.CoordinateY - height
                },
                new PointModel
                {
                    CoordinateX = point2.CoordinateX,
                    CoordinateY = point2.CoordinateY - height
                }
            };
        }

        public bool DoesLineExist(List<PointModel> potentialLine)
        {
            var firstPotentialPoint = Points.Where(point => point.CoordinateX == potentialLine[0].CoordinateX &&
                            point.CoordinateY == potentialLine[0].CoordinateY).FirstOrDefault();

            if (firstPotentialPoint == null) return false;

            var secondPotentialPoint = Points.Where(point => point.CoordinateX == potentialLine[1].CoordinateX &&
                            point.CoordinateY == potentialLine[1].CoordinateY).FirstOrDefault();

            return secondPotentialPoint == null ? false : true;
        }

        public int GetLengthBetweenPoints(int x1, int x2)
        {
            int length = x1 - x2;
            return length > 0 ? length : length * -1;
        }

        public bool WasSquareAdded(SquareModel newSquare)
        {
            foreach(var square in Squares)
            {
                if (square.Equals(newSquare))
                    return true;
            }
            return false;
        }
    }
}
