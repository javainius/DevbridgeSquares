using DevbridgeSquares.Core.Enums;
using DevbridgeSquares.Core.Interfaces;
using DevbridgeSquares.Core.Mappers;
using DevbridgeSquares.Core.Models;
using DevbridgeSquares.Core.ViewModels;
using DevbridgeSquares.Database.Repositories;
using DevbridgeSquares.Logic.AddingLogic;
using DevbridgeSquares.Logic.FindingLogic;
using System.Collections.Generic;
using System.Linq;

namespace DevbridgeSquares.App
{
    public class Application : IApplication
    {
        private PointAdder _pointAdder;
        private PointRepository _pointRepository;
        private SquareRepository _squareRepository;
        private PointsMapper _pointsMapper;
        private SquaresMapper _squareMapper;
        private SquareCalculator _squareCalculator;

        public Application()
        {
            _pointsMapper = new PointsMapper();
            _squareMapper = new SquaresMapper();
            _pointRepository = new PointRepository();
            _squareRepository = new SquareRepository();
            _pointAdder = new PointAdder(_pointRepository.GetPoints());
        }

        public void AddPoint(PointModel point)
        {
            _pointAdder.ProcessPoint(point);

            if (_pointAdder.Point.AddingState == PointAddingState.Added)
                _pointRepository.AddPoint(_pointsMapper.ModelToEntity(_pointAdder.Point));
        }

        public void DeletePoint(int id)
        {

            var idList = _squareCalculator.GetLostSquaresIds(_squareMapper.EntityListToModelList(_squareRepository.GetSquares()), id);
            _squareRepository.DeleteSquares(idList);
            _pointRepository.DeletePoint(id);
        }

        public List<PointView> GetPointList() => _pointsMapper.EntityListToViewModelList(_pointRepository.GetPoints());
        public string GetPointAddingState() => _pointAdder.Point.AddingState.ToDescriptionString();

        public List<SquareView> GetSquareList() => _squareMapper.EntityListToViewModelList(_squareRepository.GetSquares());
    }
}
