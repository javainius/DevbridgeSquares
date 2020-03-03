using Database.Models;
using Database.Repositories;
using Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.AddingLogic
{
    public class PointAddingLogic
    {
        private readonly PointRepository _pointRepository;
        public PointAddingLogic()
        {
            _pointRepository = new PointRepository();
        }
        public List<string> AddPoints(string pointsInString)
        {
            var pointParser = new PointParser(pointsInString);

            List<PointModel> points = pointParser.GetParsedPoints();

            var pointAddingStates = new List<string>(points
                .Select(point => AddPoint(point.CoordinateX, point.CoordinateY)));
            
            if(points.Count().Equals(pointAddingStates.Select(message => message
               .Equals("point successfully added to the list"))) &&
               pointParser.UnreadableLines.Equals(0))
            {
                return new List<string>() { "all points added successfully" };
            }
            else
            {
                var fileUploadingInfo = new List<string>();
                if (pointAddingStates.Contains("point successfully added to the list"))
                    fileUploadingInfo.Add("points added successfully: " +
                    pointAddingStates.Where(message => message.Equals("point successfully added to the list")).Count());

                if (pointAddingStates.Contains("this point already exists"))
                    fileUploadingInfo.Add("already existing points: " +
                    pointAddingStates.Where(message => message.Equals("this point already exists")).Count());

                if (pointAddingStates.Contains("coordinates are out of range"))
                    fileUploadingInfo.Add("points with coordinates out of range: " +
                    pointAddingStates.Where(message => message.Equals("coordinates are out of range")).Count());

                if (pointAddingStates.Contains("List of points is full"))
                    fileUploadingInfo.Add("points over 10000 points limit: " +
                    pointAddingStates.Where(message => message.Equals("List of points is full")).Count());

                if (pointParser.UnreadableLines > 0)
                {
                    fileUploadingInfo.Add("unreadable lines: " + pointParser.UnreadableLines);
                }

                return fileUploadingInfo;
            }
        }
        public string AddPoint(int coordinateX, int coordinateY)
        {
            string pointAddingState = 
                _pointRepository.DoesPointExist(coordinateX, coordinateY) ? "this point already exists" :
                !IsCoordinateAvailable(coordinateX) || !IsCoordinateAvailable(coordinateY) ? "coordinates are out of range" :
                _pointRepository.AmountOfPoints() >= 10000 ? "List of points is full" :
                "point successfully added to the list";

            if(pointAddingState == "point successfully added to the list")
            {
                _pointRepository.Add(new PointModel() { CoordinateX = coordinateX, CoordinateY = coordinateY });
            }

            return pointAddingState;
        }
        public bool IsCoordinateAvailable(int coordinate) => coordinate >= -5000 && coordinate <= 5000 ? true : false;

    }
}
