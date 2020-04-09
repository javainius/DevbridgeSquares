using DevbridgeSquares.Core.Entities;
using DevbridgeSquares.Database.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevbridgeSquares.Database.Repositories
{
    public class SquareRepository
    {
        private MainContext _context;
        public SquareRepository()
        {
            _context = new MainContext();
        }

        public void AddSquares(List<SquareEntity> squares)
        {
            _context.Squares.AddRange(squares);
            _context.SaveChanges();
        }

        public void DeleteSquare(int id)
        {
            _context.Squares.Remove(_context.Squares.Where(point => point.Id.Equals(id)).FirstOrDefault());
            _context.SaveChanges();
        }

        public void DeleteSquares(List<int> idList)
        {
            _context.Squares.RemoveRange(_context.Squares.Where(square => idList.Contains(square.Id)));
            _context.SaveChanges();
        }
        public List<SquareEntity> GetSquares() => _context.Squares.Include("Point1")
                                                                  .Include("Point2")
                                                                  .Include("Point3")
                                                                  .Include("Point4").ToList();
    }
}
