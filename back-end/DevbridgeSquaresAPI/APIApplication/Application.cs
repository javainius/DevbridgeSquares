using Database.Models;
using Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIApplication
{
    public class Application
    {
        private readonly PointRepository _pointRepository;
        public Application()
        {
            _pointRepository = new PointRepository();
        }
        public List<PointModel> GetPoints() => _pointRepository.GetPoints();
        public void Add(PointModel point = null, List<PointModel> points = null) => _pointRepository.Add(point, points);
    }
}
