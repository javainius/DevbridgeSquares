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
                cfg.CreateMap<SquareEntity, SquareModel>()
                        .ForMember(dest => dest.Points[0], opt => opt.MapFrom(src => src.Point1))
                        .ForMember(dest => dest.Points[1], opt => opt.MapFrom(src => src.Point2))
                        .ForMember(dest => dest.Points[2], opt => opt.MapFrom(src => src.Point3))
                        .ForMember(dest => dest.Points[3], opt => opt.MapFrom(src => src.Point4));
            }).CreateMapper();

            _iMapperSquareModelToSquareEntity = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SquareModel, SquareEntity>()
                        .ForMember(dest => dest.Point1, opt => opt.MapFrom(src => src.Points[0]))
                        .ForMember(dest => dest.Point2, opt => opt.MapFrom(src => src.Points[1]))
                        .ForMember(dest => dest.Point3, opt => opt.MapFrom(src => src.Points[2]))
                        .ForMember(dest => dest.Point4, opt => opt.MapFrom(src => src.Points[3]));
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
            list.AddRange(squareEntitys.Select(square => _iMapperSquareEntityToSquareModel
            .Map<SquareEntity, SquareModel>(square)));

            return list;
        }

        public List<SquareEntity> ModelListToEntitylList(List<SquareModel> squareEntitys)
        {
            var list = new List<SquareEntity>();
            list.AddRange(squareEntitys.Select(square => _iMapperSquareModelToSquareEntity
            .Map<SquareModel, SquareEntity>(square)));

            return list;
        }
        public SquareEntity ModelToEntity(SquareModel point) => _iMapperSquareModelToSquareEntity.Map<SquareModel, SquareEntity>(point);

        public SquareModel EntityToModel(SquareEntity point) => _iMapperSquareEntityToSquareModel.Map<SquareEntity, SquareModel>(point);
    }
}
