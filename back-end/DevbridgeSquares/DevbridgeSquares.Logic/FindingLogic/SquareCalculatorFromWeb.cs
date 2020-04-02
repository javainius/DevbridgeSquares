using DevbridgeSquares.Core.Entities;
using DevbridgeSquares.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevbridgeSquares.Logic.FindingLogic
{
    public class SquareCalculatorFromWeb
    {
        public int SquareCount(List<PointEntity> input)
        {
            int count = 0;

            HashSet<PointEntity> set = new HashSet<PointEntity>();

            foreach (var point in input)
                set.Add(point);

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input.Count; j++)
                {
                    if (i == j)
                        continue;

                    //For each Point i, Point j, check if b&d exist in set.
                    PointEntity[] DiagVertex = GetRestPints(input[i], input[j]);
                    var doesPoint1Exist = set.Select(point => point.CoordinateX == DiagVertex[0].CoordinateX &&
                                                 point.CoordinateY == DiagVertex[0].CoordinateY).FirstOrDefault();
                    var doesPoint2Exist = set.Select(point => point.CoordinateX == DiagVertex[1].CoordinateX &&
                                                 point.CoordinateY == DiagVertex[1].CoordinateY).FirstOrDefault();

                    if (doesPoint1Exist && doesPoint2Exist)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public PointEntity[] GetRestPints(PointEntity a, PointEntity c)
        {
            PointEntity[] res = new PointEntity[2];

            int midX = (a.CoordinateX + c.CoordinateY) / 2;
            int midY = (a.CoordinateY + c.CoordinateY) / 2;

            int Ax = a.CoordinateX - midX;
            int Ay = a.CoordinateY - midY;
            int bX = midX - Ay;
            int bY = midY + Ax;

            PointEntity b = new PointEntity(bX, bY);

            int cX = (c.CoordinateX - midX);
            int cY = (c.CoordinateY - midY);
            int dX = midX - cY;
            int dY = midY + cX;

            PointEntity d = new PointEntity(dX, dY);

            res[0] = b;
            res[1] = d;
            return res;
        }
    }
}
