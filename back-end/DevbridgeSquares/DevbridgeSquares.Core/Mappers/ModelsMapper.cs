using AutoMapper;
using DevbridgeSquares.Core.Entities;
using DevbridgeSquares.Core.Models;
using DevbridgeSquares.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevbridgeSquares.Core.Mappers
{
    public class ModelsMapper
    {
        private IMapper _iMapper { get; set; }

        public ModelsMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PointEntity, PointViewModel>();
            });

            _iMapper = config.CreateMapper();
        }

        public List<PointViewModel> EntityListToModelList(List<PointEntity> pointEntity) 
        {
            var list = new List<PointViewModel>(); 
            list.AddRange(pointEntity.Select(point => _iMapper
            .Map<PointEntity, PointViewModel>(point)));

            return list;
        }
        //public List<PointEntity> ModelToEntityList(PointsModel pointsModel)
        //{
        //    var entityList = new List<PointEntity>();
        //    entityList.AddRange(pointsModel.Points.Select(point => _iMapper
        //    .Map<PointModel, PointEntity>(point)));

        //    return entityList;
        //}
    }
}
