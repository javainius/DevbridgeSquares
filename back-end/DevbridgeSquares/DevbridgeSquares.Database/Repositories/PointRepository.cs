using DevbridgeSquares.Core.Entities;
using DevbridgeSquares.Core.Interfaces;
using DevbridgeSquares.Database.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace DevbridgeSquares.Database.Repositories
{
    public class PointRepository
    {
        private MainContext _context;
        public PointRepository()
        {
            _context = new MainContext();
        }

        public void AddPoint(PointEntity point)
        {
            _context.Points.Add(point);
            _context.SaveChanges();
        }

        public void DeletePoint(int id)
        {
            _context.Points.Remove(_context.Points.Where(point => point.Id.Equals(id)).FirstOrDefault());
            _context.SaveChanges();
        }

        public List<PointEntity> GetPoints() => _context.Points.ToList();
    }
}
