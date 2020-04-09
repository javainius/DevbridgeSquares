using DevbridgeSquares.Core.Models;
using DevbridgeSquares.Core.ViewModels;
using System.Collections.Generic;

namespace DevbridgeSquares.Core.Interfaces
{
    public interface IApplication
    {
        List<PointView> GetPointList();
        List<SquareView> GetSquareList();
        void AddPoint(PointModel point);
        string GetPointAddingState();
        void DeletePoint(int id);
    }
}
