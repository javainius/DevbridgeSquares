using DevbridgeSquares.App;
using DevbridgeSquares.Core.Interfaces;
using DevbridgeSquares.Core.Models;
using DevbridgeSquares.Core.ViewModels;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DevbridgeSquares.API.Controllers
{
    public class PointsController : ApiController
    {
        private readonly IApplication _application;
        public PointsController(IApplication application)
        {
            _application = application;
        }
        // GET api/Points/Get
        [HttpGet]
        public List<PointViewModel> GetPoints()
        {
            return _application.GetPointList();
        }

        // POST api/Points/PostPoint
        [HttpPost]
        public PostPointResponseView PostPoint([FromBody] PointModel point)
        {
            _application.AddPoint(point);

            return new PostPointResponseView(_application.GetPointAddingState(), _application.GetPointList());
        }

        // DELETE api/Points/DeletePoint
        [HttpDelete]
        public List<PointViewModel> DeletePoint([FromBody] int id)
        {
            _application.DeletePoint(id);
            return _application.GetPointList();
        }
    }
}
