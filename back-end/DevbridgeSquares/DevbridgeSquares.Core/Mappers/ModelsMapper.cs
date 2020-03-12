using AutoMapper;
using DevbridgeSquares.Core.Entities;
using DevbridgeSquares.Core.Models;
using DevbridgeSquares.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace DevbridgeSquares.Core.Mappers
{
    public class ModelsMapper
    {
        private IMapper _iMapperPointEntityToPointView { get; set; }
        private IMapper _iMapperPointEntityToPointModel { get; set; }
        private IMapper _iMapperPointModelToPointEntity { get; set; }


        public ModelsMapper()
        {
            _iMapperPointEntityToPointView = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PointEntity, PointViewModel>();
            }).CreateMapper();

            _iMapperPointEntityToPointModel = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PointEntity, PointModel>();
            }).CreateMapper();

            _iMapperPointModelToPointEntity = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PointModel, PointEntity>();
            }).CreateMapper();
        }

        public List<PointViewModel> EntityListToViewModelList(List<PointEntity> pointEntity)
        {
            var list = new List<PointViewModel>();
            list.AddRange(pointEntity.Select(point => _iMapperPointEntityToPointView
            .Map<PointEntity, PointViewModel>(point)));

            return list;
        }

        public PointEntity ModelToEntity(PointModel point) => _iMapperPointModelToPointEntity.Map<PointModel, PointEntity>(point);

        public PointModel EntityToModel(PointEntity point) => _iMapperPointEntityToPointModel.Map<PointEntity, PointModel>(point);
    }
}
