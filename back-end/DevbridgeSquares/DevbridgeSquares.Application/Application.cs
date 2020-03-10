using DevbridgeSquares.Core.Enums;
using DevbridgeSquares.Core.Mappers;
using DevbridgeSquares.Core.Models;
using DevbridgeSquares.Core.ViewModels;
using DevbridgeSquares.Database.Repositories;
using DevbridgeSquares.Logic.AddingLogic;
using System.Collections.Generic;
using System.Linq;

namespace DevbridgeSquares.Application
{
    public class Application
    {
        private PointAddingLogic _pointAddingLogic;
        private PointRepository _pointRepository;
        private ModelsMapper _mapper;

        public Application()
        {
            _mapper = new ModelsMapper();
            _pointRepository = new PointRepository();
        }

        public void SetApplication(PointModel point = null, string pointsInString = null)
        {
            _pointAddingLogic = new PointAddingLogic(_pointRepository.GetPoints(), pointsInString, point);
        }

        public void AddPoint()
        {
            _pointAddingLogic.AddOnePoint();
            _pointRepository.Add(_pointAddingLogic.AddingDbPointList.DbPointList);
        }

        public void AddPoints()
        {
            _pointAddingLogic.AddPoints();
            _pointRepository.Add(_pointAddingLogic.AddingDbPointList.DbPointList);
        }

        public List<PointViewModel> GetPointList() => _mapper.EntityListToModelList(_pointRepository.GetPoints());
        public string GetPointAddingState() => _pointAddingLogic.PointsDTO.Points.FirstOrDefault().AddingState.ToDescriptionString();

        public FileUploadingStateModel GetFileUploadingState()
        {
            return new FileUploadingStateModel()
            {
                AddingStates = _pointAddingLogic.PointsDTO.Points.Select(point => point.AddingState.ToDescriptionString()).ToList(),
                UnreadableLinesCount = _pointAddingLogic.PointsDTO.UnreadableLinesCount
            };
        }
    }
}
