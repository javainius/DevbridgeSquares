using Database.Models;
using Database.Repositories;
using Logic.AddingLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIApplication
{
    public class Application
    {
        private readonly PointAddingLogic _pointAddingLogic;
        private readonly PointRepository _pointRepository;
        public Application()
        {
            _pointAddingLogic = new PointAddingLogic();
            _pointRepository = new PointRepository();
        }
        public List<PointModel> GetPoints() => _pointRepository.GetPoints();
        public List<string> AddPoint(PointModel point) => new List<string>() { _pointAddingLogic.AddPoint(point.CoordinateX, point.CoordinateY) };
        public List<string> AddPoints(string pointsInString) => _pointAddingLogic.AddPoints(pointsInString);
    }
}
