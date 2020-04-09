using AutoMapper;
using DevbridgeSquares.Core.Entities;
using DevbridgeSquares.Core.Models;
using DevbridgeSquares.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace DevbridgeSquares.Core.Mappers
{
    public class SquaresMapper
    {
        private IMapper _iMapperSquareEntityToSquareView { get; set; }
        private IMapper _iMapperSquareEntityToSquareModel { get; set; }
        private IMapper _iMapperSquareModelToSquareEntity { get; set; }


        public SquaresMapper()
        {
            _iMapperSquareEntityToSquareView = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SquareEntity, SquareView>();
                cfg.CreateMap<PointEntity, PointView>();
            }).CreateMapper();

            _iMapperSquareEntityToSquareModel = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SquareEntity, SquareModel>();
                cfg.CreateMap<PointEntity, PointModel>();
            }).CreateMapper();

            _iMapperSquareModelToSquareEntity = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SquareModel, SquareEntity>();
            }).CreateMapper();
        }

        public List<SquareView> EntityListToViewModelList(List<SquareEntity> squareEntitys)
        {
            var list = new List<SquareView>();
            list.AddRange(squareEntitys.Select(square => _iMapperSquareEntityToSquareView
            .Map<SquareEntity, SquareView>(square)));

            return list;
        }

        public List<SquareModel> EntityListToModelList(List<SquareEntity> squareEntitys)
        {
            var list = new List<SquareModel>();
            list.AddRange(squareEntitys.Select(square => _iMapperSquareEntityToSquareView
            .Map<SquareEntity, SquareModel>(square)));

            return list;
        }
        public SquareEntity ModelToEntity(SquareModel point) => _iMapperSquareModelToSquareEntity.Map<SquareModel, SquareEntity>(point);

        public SquareModel EntityToModel(SquareEntity point) => _iMapperSquareEntityToSquareModel.Map<SquareEntity, SquareModel>(point);
    }
}
