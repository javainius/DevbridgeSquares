using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic.Helpers
{
    public class PointParser
    {
        private string _pointsInString;
        public int UnreadableLines { get; set; }
        public PointParser(string pointsInString)
        {
            _pointsInString = pointsInString;
            UnreadableLines = 0;
        }

        public List<PointModel> GetParsedPoints()
        {
            string[] linesOfPoints = Regex.Split(_pointsInString, "\r\n");
            var parsedLines = linesOfPoints.Select(line => line.Split(' ')).ToList();
            var points = new List<PointModel>();

            foreach (var line in parsedLines)
            {
                int number;
                bool checkIfInts = line.Any(symbol => int.TryParse(symbol, out number));
                if (line.Length != 2 || !checkIfInts)
                {
                    UnreadableLines++;
                }
                else
                {
                    points.Add(new PointModel()
                    {
                        CoordinateX = int.Parse(line[0]),
                        CoordinateY = int.Parse(line[1])
                    });
                }
            }

            return points;
        }
    }
}
