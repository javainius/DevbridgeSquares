using DevbridgeSquares.Core.Enums;
using DevbridgeSquares.Core.Interfaces;
using DevbridgeSquares.Core.Mappers;
using DevbridgeSquares.Core.Models;
using DevbridgeSquares.Core.ViewModels;
using DevbridgeSquares.Database.Repositories;
using DevbridgeSquares.Logic.AddingLogic;
using System.Collections.Generic;
using System.Linq;

namespace DevbridgeSquares.App
{
    public class Application : IApplication
    {
        private PointAddingLogic _pointAddingLogic;
        private PointRepository _pointRepository;
        private ModelsMapper _mapper;

        public Application()
        {
            _mapper = new ModelsMapper();
            _pointRepository = new PointRepository();
            _pointAddingLogic = new PointAddingLogic(_pointRepository.GetPoints());
        }

        public void AddPoint(PointModel point)
        {
            _pointAddingLogic.ProcessPoint(point);

            if(_pointAddingLogic.Point.AddingState == PointAddingState.Added)
            _pointRepository.AddPoint(_mapper.ModelToEntity(_pointAddingLogic.Point));
        }

        public List<PointViewModel> GetPointList() => _mapper.EntityListToViewModelList(_pointRepository.GetPoints());
        public string GetPointAddingState() => _pointAddingLogic.Point.AddingState.ToDescriptionString();
    }
}
