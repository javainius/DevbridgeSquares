﻿//using DevbridgeSquares.Core.Models;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.RegularExpressions;

//namespace DevbridgeSquares.Logic.DbItemCopies
//{
//    public class PointParser
//    {
//        private string _pointsInString;
//        public int UnreadableLines { get; set; }
//        public PointParser(string pointsInString)
//        {
//            _pointsInString = pointsInString;
//            UnreadableLines = 0;
//        }

//        public List<PointModel> GetParsedPoints()
//        {
//            string[] linesOfPoints = Regex.Split(_pointsInString, "\r\n");
//            var parsedLines = linesOfPoints.Select(line => line.Split(' ')).ToList();
//            var points = new List<PointModel>();

//            foreach (var line in parsedLines)
//            {
//                bool isIntString = line.ToArray().All(ch => ch.All(char.IsDigit));
//                if (line.Length != 2 || !isIntString)
//                {
//                    UnreadableLines++;
//                }
//                else
//                    points.Add(new PointModel(int.Parse(line[0]), int.Parse(line[1])));
//            }

//            return points;
//        }
//    }
//}
