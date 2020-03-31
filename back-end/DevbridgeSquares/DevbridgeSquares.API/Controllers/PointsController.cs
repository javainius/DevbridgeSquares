using DevbridgeSquares.Core.Interfaces;
using DevbridgeSquares.Core.Models;
using DevbridgeSquares.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DevbridgeSquares.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        private readonly IApplication _application;
        public PointsController(IApplication application)
        {
            _application = application;
        }
        // GET api/Points
        [HttpGet]
        public List<PointViewModel> GetPoints()
        {
            var points = _application.GetPointList();
            return points;
        }

        // POST api/Points
        [HttpPost]
        public PostPointResponseView PostPoint(PointModel point)
        {
            _application.AddPoint(point);

            return new PostPointResponseView(_application.GetPointAddingState(), _application.GetPointList());
        }

        // DELETE api/Points
        [HttpDelete]
        public List<PointViewModel> DeletePoint([FromBody]int id)
        {
            _application.DeletePoint(id);
            return _application.GetPointList();
        }
    }
}