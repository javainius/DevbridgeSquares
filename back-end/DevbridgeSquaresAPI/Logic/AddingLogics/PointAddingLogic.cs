using Database.Models;
using Database.Repositories;
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
        public string AddPoint(int coordinateX, int coordinateY)
        {
            string pointAddingState = 
                _pointRepository.DoesPointExist(coordinateX, coordinateY) ? "this point already exists" :
                !IsCoordinateAvailable(coordinateX) || !IsCoordinateAvailable(coordinateY) ? "coordinates are out of range" :
                _pointRepository.AmountOfPoints() >= 10000 ? "List of points is full" :
                "point is added to the list";

            if(pointAddingState == "point is added to the list")
            {
                _pointRepository.Add(new PointModel() { CoordinateX = coordinateX, CoordinateY = coordinateY });
            }

            return pointAddingState;
        }
        public bool IsCoordinateAvailable(int coordinate) => coordinate >= -5000 && coordinate <= 5000 ? true : false;
    }
}
