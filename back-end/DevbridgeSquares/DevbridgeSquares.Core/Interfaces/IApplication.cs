using DevbridgeSquares.Core.Models;
using DevbridgeSquares.Core.ViewModels;
using System.Collections.Generic;

namespace DevbridgeSquares.Core.Interfaces
{
    public interface IApplication
    {
        List<PointViewModel> GetPointList();
        void AddPoint(PointModel point);
        string GetPointAddingState();
        void DeletePoint(int id);
    }
}
