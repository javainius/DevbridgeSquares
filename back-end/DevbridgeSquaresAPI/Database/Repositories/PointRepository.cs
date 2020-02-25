using APIDatabase.Contexts;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class PointRepository
    {
        private MainContext _context;
        public PointRepository()
        {
            _context = new MainContext();
        }

        public void Add(PointModel point = null, List<PointModel> points = null)
        {
            if (point == null) _context.Points.AddRange(points);
            else _context.Points.Add(point);

            _context.SaveChanges();
        }
        public bool DoesPointExist(int coordinateX, int coordinateY) 
        {
            return _context.Points.ToList().Exists(point =>
                    point.CoordinateX.Equals(coordinateX) &&
                    point.CoordinateY.Equals(coordinateY));
        } 
        public int AmountOfPoints()
        {
            return _context.Points.Count();
        }
        public List<PointModel> GetPoints() => _context.Points.ToList();
    }
}
