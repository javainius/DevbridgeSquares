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

        public void UpdateSquareRepository(List<SquareEntity> squares)
        {
            _context.Squares.AddRange(squares.Where(newSquare => 
            _context.Squares.All(oldSquare => oldSquare.Point1 != newSquare.Point1 &&
                                              oldSquare.Point2 != newSquare.Point2 &&
                                              oldSquare.Point3 != newSquare.Point3 &&
                                              oldSquare.Point4 != newSquare.Point4)));
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
