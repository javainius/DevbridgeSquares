using AutoMapper;
using DevbridgeSquares.Core.Entities;
using DevbridgeSquares.Core.Models;
using DevbridgeSquares.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace DevbridgeSquares.Core.Mappers
{
    public class PointsMapper
    {
        private IMapper _iMapperPointEntityToPointView { get; set; }
        private IMapper _iMapperPointEntityToPointModel { get; set; }
        private IMapper _iMapperPointModelToPointEntity { get; set; }


        public PointsMapper()
        {
            _iMapperPointEntityToPointView = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PointEntity, PointView>();
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

        public List<PointView> EntityListToViewModelList(List<PointEntity> pointEntity)
        {
            var list = new List<PointView>();
            list.AddRange(pointEntity.Select(point => _iMapperPointEntityToPointView
            .Map<PointEntity, PointView>(point)));

            return list;
        }

        public List<PointModel> EntityListToModelList(List<PointEntity> pointEntity)
        {
            var list = new List<PointModel>();
            list.AddRange(pointEntity.Select(point => _iMapperPointEntityToPointView
            .Map<PointEntity, PointModel>(point)));

            return list;
        }

        public PointEntity ModelToEntity(PointModel point) => _iMapperPointModelToPointEntity.Map<PointModel, PointEntity>(point);

        public PointModel EntityToModel(PointEntity point) => _iMapperPointEntityToPointModel.Map<PointEntity, PointModel>(point);
    }
}
